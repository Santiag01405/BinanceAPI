using System.Text.Json.Serialization;
using BinanceAPI.Models;

namespace BinanceAPI;

[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    GenerationMode = JsonSourceGenerationMode.Metadata)]
[JsonSerializable(typeof(Todo[]))]
[JsonSerializable(typeof(AdPublishRequest))]
[JsonSerializable(typeof(TradeMethod))]
[JsonSerializable(typeof(LoginRequest))]
[JsonSerializable(typeof(LoginResponse))]
public partial class AppJsonSerializerContext : JsonSerializerContext
{
}

