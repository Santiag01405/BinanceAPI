namespace BinanceAPI.Models;

public class ChatMessagesQueryParams
{
    public string? ChatMessageType { get; set; }
    public long? Id { get; set; }
    public string? Order { get; set; }
    public string? OrderNo { get; set; }
    public int Page { get; set; }
    public int Rows { get; set; }
    public string? Sort { get; set; }
}
