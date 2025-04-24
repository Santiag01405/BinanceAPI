using BinanceAPI.Models;
using BinanceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BinanceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
        Console.WriteLine("AuthController loaded");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            var result = _authService.Authenticate(request.Email, request.Password);
            return Ok(result);
        }
        catch
        {
            return Unauthorized("Invalid credentials");
        }
    }

    [HttpGet("ping")]
    public IActionResult Ping() => Ok("pong");
}
