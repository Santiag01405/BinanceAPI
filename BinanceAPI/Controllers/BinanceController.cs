using Microsoft.AspNetCore.Mvc;
using BinanceAPI.Models;
using BinanceAPI.Services;

namespace BinanceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BinanceController : ControllerBase
{
    private readonly BinanceApiClient _binanceClient;

    public BinanceController(BinanceApiClient binanceClient)
    {
        _binanceClient = binanceClient;
    }

    [HttpGet("ad-detail/{adsNo}")]
    public async Task<IActionResult> GetAdDetail(string adsNo)
    {
        var result = await _binanceClient.GetAdDetailAsync(adsNo);
        return Ok(result);
    }

    [HttpPost("post-ad")]
    public async Task<IActionResult> PostAd([FromBody] AdPublishRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _binanceClient.PostAdAsync(request);
        return Ok(result);
    }
}
