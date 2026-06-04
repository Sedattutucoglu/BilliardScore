using BilliardScore.DTOs.Auth;
using BilliardScore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BilliardScore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
       var result = await _authService.LoginAsync(request);
        if (!result)
        {
            return Unauthorized("Kullanıcı adı veya şifre hatalı.");
        }

        return Ok(true);
    }
}