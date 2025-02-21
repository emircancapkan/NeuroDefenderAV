namespace NeuroDefenderAV.Models
{
    public class ScanViewModel
    {
        public string ScanType { get; set; } = string.Empty;
        public DateTime LastScanDate { get; set; }
        public int TotalScannedFiles { get; set; }
        public int ThreatsFound { get; set; }
        public bool IsScanRunning { get; set; }
        public int ScanProgress { get; set; }
        public List<string> AvailableScanTypes { get; set; } = new List<string>
        {
            "Smart Scan",
            "Full Virus Scan",
            "Targeted Scan",
            "Boot-Time Scan",
            "Custom Scan"
        };
    }
} 