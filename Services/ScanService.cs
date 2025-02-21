using NeuroDefenderAV.Services.Interfaces;
using NeuroDefenderAV.Models;
using Microsoft.Extensions.Logging;

namespace NeuroDefenderAV.Services
{
    public class ScanService : IScanService
    {
        private readonly ILogger<ScanService> _logger;

        public ScanService(ILogger<ScanService> logger)
        {
            _logger = logger;
        }

        public ScanResult PerformQuickScan()
        {
            _logger.LogInformation("Hızlı tarama başlatıldı");
            
            return new ScanResult
            {
                IsCompleted = true,
                ScannedFiles = 1000,
                ThreatsFound = 0,
                Threats = new List<ThreatInfo>(),
                ScanStartTime = DateTime.Now.AddMinutes(-2),
                ScanEndTime = DateTime.Now,
                ScanType = "Quick",
                ScanPath = "System Critical Paths"
            };
        }

        public ScanResult PerformFullScan()
        {
            _logger.LogInformation("Tam tarama başlatıldı");
            
            return new ScanResult
            {
                IsCompleted = true,
                ScannedFiles = 50000,
                ThreatsFound = 0,
                Threats = new List<ThreatInfo>(),
                ScanStartTime = DateTime.Now.AddMinutes(-15),
                ScanEndTime = DateTime.Now,
                ScanType = "Full",
                ScanPath = "All Drives"
            };
        }

        public ScanResult PerformCustomScan(string path)
        {
            _logger.LogInformation($"Özel tarama başlatıldı: {path}");
            
            return new ScanResult
            {
                IsCompleted = true,
                ScannedFiles = 100,
                ThreatsFound = 0,
                Threats = new List<ThreatInfo>(),
                ScanStartTime = DateTime.Now.AddMinutes(-1),
                ScanEndTime = DateTime.Now,
                ScanType = "Custom",
                ScanPath = path
            };
        }
    }
} 