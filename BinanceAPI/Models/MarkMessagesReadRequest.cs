namespace BinanceAPI.Models;

public class MarkMessagesReadRequest
{
    public string OrderNo { get; set; } = string.Empty;
    public long UserId { get; set; }
}
