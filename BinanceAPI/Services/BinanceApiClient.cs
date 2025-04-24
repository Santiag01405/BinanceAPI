using Microsoft.Extensions.Options;
using BinanceAPI.Configurations;
using BinanceAPI.Models;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace BinanceAPI.Services
{
    public class BinanceApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly BinanceSettings _settings;

        public BinanceApiClient(HttpClient httpClient, IOptions<BinanceSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
        }

        public async Task<string> PostAdAsync(AdPublishRequest adPayload)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);
            var fullUrl = $"{_settings.BaseUrl}/sapi/v1/c2c/ads/post?{queryString}&signature={signature}";

            var json = JsonSerializer.Serialize(adPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, fullUrl);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAdDetailAsync(string adsNo)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"adsNo={adsNo}&timestamp={timestamp}";
            var signature = Sign(queryString);

            var fullUrl = $"{_settings.BaseUrl}/sapi/v1/c2c/ads/getDetailByNo?{queryString}&signature={signature}";

            var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }


        private string Sign(string payload)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
