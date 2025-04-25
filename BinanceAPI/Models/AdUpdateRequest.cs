namespace BinanceAPI.Models;

public class AdUpdateRequest
{
    public string AdvNo { get; set; } = string.Empty;
    public int AdvStatus { get; set; }
    public string Asset { get; set; } = string.Empty;
    public string AuthType { get; set; } = "FID02";
    public string AutoReplyMsg { get; set; } = string.Empty;
    public int BuyerRegPositionLimit { get; set; }
    public int BuyerKycLimit { get; set; }
    public int BuyerRegDaysLimit { get; set; }
    public string Code { get; set; } = string.Empty;
    public string EmailVerifyCode { get; set; } = string.Empty;
    public string FiatUnit { get; set; } = string.Empty;
    public string GoogleVerifyCode { get; set; } = string.Empty;
    public decimal InitAmount { get; set; }
    public decimal MaxSingleTransAmount { get; set; }
    public decimal MinSingleTransAmount { get; set; }
    public string MobileVerifyCode { get; set; } = string.Empty;
    public int PayTimeLimit { get; set; }
    public decimal Price { get; set; }
    public decimal PriceFloatingRatio { get; set; }
    public int PriceType { get; set; }
    public decimal RateFloatingRatio { get; set; }
    public string Remarks { get; set; } = string.Empty;
    public int SaveAsTemplate { get; set; }
    public int TakerAdditionalKycRequired { get; set; }
    public string TemplateName { get; set; } = string.Empty;
    public List<TradeMethod> TradeMethods { get; set; } = new();
    public string TradeType { get; set; } = string.Empty;
    public string UpdateMode { get; set; } = string.Empty;
    public int UserAllTradeCountMax { get; set; }
    public int UserAllTradeCountMin { get; set; }
    public int UserBuyTradeCountMax { get; set; }
    public int UserBuyTradeCountMin { get; set; }
    public int UserSellTradeCountMax { get; set; }
    public int UserSellTradeCountMin { get; set; }
    public int UserTradeCompleteCountMin { get; set; }
    public int UserTradeCompleteRateFilterTime { get; set; }
    public int UserTradeCompleteRateMin { get; set; }
    public int UserTradeCountFilterTime { get; set; }
    public int UserTradeType { get; set; }
    public string UserTradeVolumeAsset { get; set; } = string.Empty;
    public int UserTradeVolumeFilterTime { get; set; }
    public decimal UserTradeVolumeMax { get; set; }
    public decimal UserTradeVolumeMin { get; set; }
    public string YubikeyVerifyCode { get; set; } = string.Empty;
}
