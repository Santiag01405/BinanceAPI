namespace BinanceAPI.Configurations;

public class JwtSettings
{
    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = "BinanceAPI";
    public string Audience { get; set; } = "BinanceAPIUsers";
    public int ExpiryMinutes { get; set; } = 60;
}
