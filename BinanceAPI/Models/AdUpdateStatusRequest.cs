namespace BinanceAPI.Models;

public class AdUpdateStatusRequest
{
    public List<string> AdvNos { get; set; } = new();
    public int AdvStatus { get; set; } // 0 = OFFLINE, 1 = ONLINE
}
