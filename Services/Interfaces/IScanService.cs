using NeuroDefenderAV.Models;

namespace NeuroDefenderAV.Services.Interfaces
{
    public interface IScanService
    {
        ScanResult PerformQuickScan();
        ScanResult PerformFullScan();
        ScanResult PerformCustomScan(string path);
    }
} 