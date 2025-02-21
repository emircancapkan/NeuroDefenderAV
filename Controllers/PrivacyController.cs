using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace NeuroDefender.Controllers
{
    public class PrivacyController : Controller
    {
        private readonly ILogger<PrivacyController> _logger;

        public PrivacyController(ILogger<PrivacyController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new PrivacyViewModel
            {
                DataCollection = true,
                WebcamProtection = true,
                RansomwareProtection = true,
                LastPrivacyCheck = DateTime.Now
            };

            return View(model);
        }

        public IActionResult Configure()
        {
            return View();
        }
    }
} 