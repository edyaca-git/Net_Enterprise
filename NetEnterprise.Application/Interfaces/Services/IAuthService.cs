using NetEnterprise.Application.DTOs.User;
using NetEnterprise.Shared.Common;

namespace NetEnterprise.Application.Interfaces.Services;

public interface IAuthService
{
    Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request);

    Task<ApiResponse<UserRegisteredResponse>> RegisterAsync(RegisterUserDto request);

    Task<ApiResponse<CurrentUserResponse>> GetCurrentUserAsync(int userId);
}