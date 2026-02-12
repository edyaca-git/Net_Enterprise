using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetEnterprise.Application.DTOs.User;
using NetEnterprise.Application.Interfaces.Services;
using NetEnterprise.Shared.Common;

namespace NetEnterprise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    public AuthController(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    /// <summary>
    /// Iniciar sesión
    /// </summary>
    [HttpPost("login")]
    [ProducesResponseType(typeof(ApiResponse<LoginResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ApiResponse<LoginResponse>>> Login([FromBody] LoginRequest request)
    {
        var response = await _authService.LoginAsync(request);
        return StatusCode(response.StatusCode, response);
    }

    /// <summary>
    /// Registrar nuevo usuario
    /// </summary>
    [HttpPost("register")]
    [ProducesResponseType(typeof(ApiResponse<UserRegisteredResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ApiResponse<UserRegisteredResponse>>> Register([FromBody] RegisterUserDto request)
    {
        //request.UserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value ?? "1");
        request.UserId = int.Parse(User.FindFirst("userId")?.Value ?? "1");
        var response = await _authService.RegisterAsync(request);
        return StatusCode(response.StatusCode, response);
    }

    /// <summary>
    /// Obtener información del usuario autenticado
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponse<CurrentUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ApiResponse<CurrentUserResponse>>> GetCurrentUser()
    {
        var userId = int.Parse(User.FindFirst("userId")?.Value ?? "0");
        var response = await _authService.GetCurrentUserAsync(userId);
        return StatusCode(response.StatusCode, response);
    }
}