namespace NeuroDefenderAV.Models
{
    public class ScanResult
    {
        public bool IsCompleted { get; set; }
        public int ScannedFiles { get; set; }
        public int ThreatsFound { get; set; }
        public List<ThreatInfo> Threats { get; set; }
        public DateTime ScanStartTime { get; set; }
        public DateTime ScanEndTime { get; set; }
        public string ScanType { get; set; }
        public string ScanPath { get; set; }
    }

    public class ThreatInfo
    {
        public string FilePath { get; set; }
        public string ThreatName { get; set; }
        public string ThreatSeverity { get; set; }
        public DateTime DetectionTime { get; set; }
    }
} 