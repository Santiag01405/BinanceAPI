using Microsoft.AspNetCore.Mvc;
using BinanceAPI.Models;
using BinanceAPI.Services;
using Microsoft.AspNetCore.Authorization;

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

    //Obtener detalles de un anuncio
    [HttpGet("ad-detail/{adsNo}")]
    public async Task<IActionResult> GetAdDetail(string adsNo)
    {
        var result = await _binanceClient.GetAdDetailAsync(adsNo);
        return Ok(result);
    }
    
    //Crear anuncio
    [HttpPost("post-ad")]
    //[Authorize]
    public async Task<IActionResult> PostAd([FromBody] AdPublishRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _binanceClient.PostAdAsync(request);
        return Ok(result);
    }


    //Actualizar anuncio
    [HttpPost("update-ad")]
    public async Task<IActionResult> UpdateAd([FromBody] AdUpdateRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _binanceClient.UpdateAdAsync(request);
        return Ok(result);
    }

    //Actualizar estado del anuncio
    [HttpPost("update-ad-status")]
    public async Task<IActionResult> UpdateAdStatus([FromBody] AdUpdateStatusRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _binanceClient.UpdateAdStatusAsync(request);
        return Ok(result);
    }

    //Finalizar orden
    [HttpPost("release-coin")]
    public async Task<IActionResult> ReleaseCoin([FromBody] ReleaseCoinRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _binanceClient.ReleaseCoinAsync(request);
        return Ok(result);
    }

    //Distintos endpoints para el chat

    [HttpPost("chat-image-url")]
    public async Task<IActionResult> GetChatImageUploadUrl([FromBody] ChatImageUrlRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _binanceClient.GetChatImageUploadUrlAsync(request);
        return Ok(result);
    }

    [HttpPost("mark-messages-read")]
    public async Task<IActionResult> MarkMessagesRead([FromBody] MarkMessagesReadRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _binanceClient.MarkMessagesAsReadAsync(request);
        return Ok(result);
    }

    [HttpGet("chat-credentials")]
    public async Task<IActionResult> GetChatCredentials()
    {
        var result = await _binanceClient.GetChatCredentialsAsync();
        return Ok(result);
    }

    [HttpGet("chat-messages")]
    public async Task<IActionResult> GetChatMessages([FromQuery] ChatMessagesQueryParams query)
    {
        var result = await _binanceClient.GetChatMessagesPaginatedAsync(query);
        return Ok(result);
    }

}
