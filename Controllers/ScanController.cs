using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using NeuroDefenderAV.Models;
using NeuroDefenderAV.Services.Interfaces;

namespace NeuroDefenderAV.Controllers
{
    public class ScanController : Controller
    {
        private readonly ILogger<ScanController> _logger;
        private readonly IScanService _scanService;

        public ScanController(ILogger<ScanController> logger, IScanService scanService)
        {
            _logger = logger;
            _scanService = scanService;
        }

        public IActionResult Index()
        {
            var model = new ScanViewModel
            {
                LastScanDate = DateTime.Now.AddDays(-1),
                TotalScannedFiles = 50000,
                ThreatsFound = 0,
                IsScanRunning = false,
                ScanProgress = 0
            };

            return View(model);
        }

        public IActionResult QuickScan()
        {
            return RedirectToAction("Index", new { scanStarted = "quick" });
        }

        public IActionResult FullScan()
        {
            return RedirectToAction("Index", new { scanStarted = "full" });
        }

        public IActionResult TargetedScan()
        {
            return RedirectToAction("Index", new { scanStarted = "targeted" });
        }

        public IActionResult BootTimeScan()
        {
            return RedirectToAction("Index", new { scanStarted = "bootTime" });
        }

        public IActionResult CustomScan(string path)
        {
            var scanResult = _scanService.PerformCustomScan(path);
            return View(scanResult);
        }
    }
} 