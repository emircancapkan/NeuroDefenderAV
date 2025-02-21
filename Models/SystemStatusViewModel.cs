public class SystemStatusViewModel
{
    public string SystemHealth { get; set; }
    public DateTime LastScanDate { get; set; }
    public int ThreatCount { get; set; }
    public bool IsRealTimeProtectionEnabled { get; set; }
} 