using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using NeuroDefenderAV.Models;
namespace Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Status()
        {
            var model = new SecurityStatusViewModel
            {
                IsProtected = true,
                RealTimeProtection = true,
                FirewallStatus = true,
                LastUpdateDate = DateTime.Now,
                SystemVulnerabilities = new List<SystemVulnerability>()
            };

            return View(model);
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult UpdateDatabase()
        {
            // Virüs veritabanını güncelleme işlemi
            return RedirectToAction("Status");
        }
    }
} 