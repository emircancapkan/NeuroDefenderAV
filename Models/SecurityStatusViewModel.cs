using System;
using System.Collections.Generic;

namespace NeuroDefenderAV.Models
{
    public class SecurityStatusViewModel
    {
        public bool IsProtected { get; set; }
        public bool RealTimeProtection { get; set; }
        public bool FirewallStatus { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public List<SystemVulnerability> SystemVulnerabilities { get; set; } = new();
    }
} 