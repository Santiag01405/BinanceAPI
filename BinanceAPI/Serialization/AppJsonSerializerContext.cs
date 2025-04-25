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
[JsonSerializable(typeof(AdUpdateRequest))]
[JsonSerializable(typeof(AdUpdateStatusRequest))]
[JsonSerializable(typeof(ReleaseCoinRequest))]
[JsonSerializable(typeof(ChatImageUrlRequest))]
[JsonSerializable(typeof(MarkMessagesReadRequest))]
[JsonSerializable(typeof(Microsoft.AspNetCore.Mvc.ValidationProblemDetails))]
public partial class AppJsonSerializerContext : JsonSerializerContext
{
}

