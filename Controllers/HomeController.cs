using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NeuroDefenderAV.Models;
using System.ServiceProcess;

namespace NeuroDefenderAV.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var systemStatus = new SystemStatusViewModel
        {
            SystemHealth = GetSystemHealth(),
            LastScanDate = DateTime.Now.AddDays(-1),
            ThreatCount = 0,
            IsRealTimeProtectionEnabled = true
        };
        return View(systemStatus);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private string GetSystemHealth()
    {
        try
        {
            // CPU kullanımını kontrol et
            var cpuUsage = GetCpuUsage();
            
            // RAM kullanımını kontrol et
            var memoryUsage = GetMemoryUsage();
            
            // Disk alanı kontrolü
            var diskSpace = GetAvailableDiskSpace();
            
            // Windows güvenlik servisleri kontrolü
            var securityServices = CheckSecurityServices();
            
            // Windows Update durumu
            var windowsUpdateStatus = CheckWindowsUpdateStatus();

            // Genel sistem sağlığını değerlendir
            if (cpuUsage < 80 && memoryUsage < 90 && diskSpace > 10 && 
                securityServices && windowsUpdateStatus)
            {
                return "İyi";
            }
            else if (cpuUsage < 90 && memoryUsage < 95 && diskSpace > 5 && 
                    securityServices)
            {
                return "Orta";
            }
            else
            {
                return "Kritik";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Sistem sağlığı kontrolü sırasında hata: {ex.Message}");
            return "Bilinmiyor";
        }
    }

    private float GetCpuUsage()
    {
        using (var counter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
        {
            counter.NextValue(); // İlk okuma her zaman 0 döner
            Thread.Sleep(1000); // 1 saniye bekle
            return counter.NextValue(); // Gerçek CPU kullanımını al
        }
    }

    private float GetMemoryUsage()
    {
        using (var counter = new PerformanceCounter("Memory", "% Committed Bytes In Use"))
        {
            return counter.NextValue();
        }
    }

    private double GetAvailableDiskSpace()
    {
        var drive = new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory));
        var freeSpaceGB = drive.AvailableFreeSpace / (1024.0 * 1024 * 1024);
        var totalSpaceGB = drive.TotalSize / (1024.0 * 1024 * 1024);
        return (freeSpaceGB / totalSpaceGB) * 100;
    }

    private bool CheckSecurityServices()
    {
        var services = new[]
        {
            "WinDefend", // Windows Defender
            "MpsSvc",    // Windows Firewall
            "SecurityHealthService" // Windows Security Health Service
        };

        foreach (var service in services)
        {
            try
            {
                var serviceStatus = ServiceController.GetServices()
                    .FirstOrDefault(s => s.ServiceName == service)?.Status;
                
                if (serviceStatus != ServiceControllerStatus.Running)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        
        return true;
    }

    private bool CheckWindowsUpdateStatus()
    {
        try
        {
            // Windows Update durumunu kontrol etmek için alternatif bir yöntem
            var windowsUpdateService = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == "wuauserv");

            if (windowsUpdateService != null)
            {
                return windowsUpdateService.Status == ServiceControllerStatus.Running;
            }

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Windows Update kontrolü sırasında hata: {ex.Message}");
            return false;
        }
    }
}
