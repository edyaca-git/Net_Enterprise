using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetEnterprise.Api.Services;
using NetEnterprise.Application.DTOs.User;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Application.Interfaces.Services;
using NetEnterprise.Domain.Entities.Security;
using NetEnterprise.Shared.Common;
using System.Security.Cryptography;
using System.Text;

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

        if (response.Success && response.Data != null)
        {
            // Obtener el usuario para generar el token
            var user = new Domain.Entities.Security.User
            {
                UserId = response.Data.UserId,
                UserAccount = response.Data.UserAccount,
                Email = response.Data.Email,
                Name = response.Data.Name,
                BranchId = response.Data.BranchId,
                Role = new Domain.Entities.Security.Role
                {
                    RoleCode = response.Data.Role
                }
            };

            response.Data.Token = _tokenService.GenerateToken(user);
        }

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
        request.UserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value ?? "1");
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
        var userIdClaim = User.FindFirst("userId")?.Value;

        if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
        {
            return Unauthorized();
        }

        var response = await _authService.GetCurrentUserAsync(userId);
        return StatusCode(response.StatusCode, response);
    }
}