namespace BinanceAPI.Models
{
    public class AdPublishRequest
    {
        public string Asset { get; set; } = "USDT";
        public string FiatUnit { get; set; } = "ARS";
        public string TradeType { get; set; } = "SELL";
        public string AuthType { get; set; } = "FID02";
        public string AutoReplyMsg { get; set; } = "";
        public int Classify { get; set; }
        public string Code { get; set; } = "";
        public decimal Price { get; set; }
        public decimal MinSingleTransAmount { get; set; }
        public decimal MaxSingleTransAmount { get; set; }
        public bool OnlineNow { get; set; } = true;
        public List<TradeMethod> TradeMethods { get; set; } = new();
    }

    public class TradeMethod
    {
        public string Identifier { get; set; } = "";
        public string PayId { get; set; } = "";
        public string PayType { get; set; } = "";
    }
}
