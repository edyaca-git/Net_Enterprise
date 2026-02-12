using NetEnterprise.Application.DTOs.User;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Application.Interfaces.Services;
using NetEnterprise.Domain.Entities.Security;
using NetEnterprise.Shared.Common;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        ICountryRepository countryRepository,
        IPasswordHasher passwordHasher,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _countryRepository = countryRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByUserAccountAsync(request.UserAccount);

        if (user == null)
        {
            return ApiResponse<LoginResponse>.ErrorResponse(
                "Usuario o contraseña incorrectos",
                401
            );
        }

        if (!user.Active)
        {
            return ApiResponse<LoginResponse>.ErrorResponse(
                "Usuario inactivo. Contacte al administrador.",
                401
            );
        }

        // Verificar si está bloqueado
        if (user.BlockedToDate.HasValue && user.BlockedToDate.Value > DateTime.UtcNow)
        {
            return ApiResponse<LoginResponse>.ErrorResponse(
                $"Usuario bloqueado hasta {user.BlockedToDate.Value:dd/MM/yyyy HH:mm}",
                401
            );
        }

        // Verificar password
        if (!_passwordHasher.VerifyPassword(user.Password!, request.Password))
        {
            await _userRepository.IncrementFailedLoginAttemptsAsync(user.UserId);

            var updatedUser = await _userRepository.GetByIdAsync(user.UserId);

            if (updatedUser!.IncorrectPasswordAttempts >= 5)
            {
                await _userRepository.BlockUserAsync(user.UserId, DateTime.UtcNow.AddMinutes(30));

                return ApiResponse<LoginResponse>.ErrorResponse(
                    "Usuario bloqueado por 30 minutos debido a múltiples intentos fallidos",
                    401
                );
            }

            return ApiResponse<LoginResponse>.ErrorResponse(
                "Usuario o contraseña incorrectos",
                401
            );
        }

        // Login exitoso
        await _userRepository.ResetFailedLoginAttemptsAsync(user.UserId);

        //  GENERAR TOKEN AQUÍ EN EL SERVICIO
        var token = _tokenService.GenerateToken(user);

        var response = new LoginResponse
        {
            Token = token,
            UserId = user.UserId,
            UserAccount = user.UserAccount,
            Email = user.Email,
            Name = user.Name,
            Role = user.Role.RoleCode,
            BranchId = user.BranchId
        };

        return ApiResponse<LoginResponse>.SuccessResponse(response, "Login exitoso");
    }

    public async Task<ApiResponse<UserRegisteredResponse>> RegisterAsync(RegisterUserDto request)
    {
        // Validar UserAccount único
        if (await _userRepository.ExistsByUserAccountAsync(request.UserAccount))
        {
            return ApiResponse<UserRegisteredResponse>.ErrorResponse(
                "El nombre de usuario ya está en uso",
                400
            );
        }

        // Validar Email único
        if (await _userRepository.ExistsByEmailAsync(request.Email))
        {
            return ApiResponse<UserRegisteredResponse>.ErrorResponse(
                "El email ya está registrado",
                400
            );
        }

        // Validar que exista el país
        var country = await _countryRepository.GetByIdAsync(request.CountryId);
        if (country == null)
        {
            return ApiResponse<UserRegisteredResponse>.ErrorResponse(
                "El país seleccionado no es válido",
                400
            );
        }

        // Obtener rol USER por defecto
        var userRole = await _roleRepository.GetByCodeAsync("USER");
        if (userRole == null)
        {
            return ApiResponse<UserRegisteredResponse>.ErrorResponse(
                "Error en la configuración del sistema",
                500
            );
        }

        // Crear nuevo usuario
        var newUser = new User
        {
            UserAccount = request.UserAccount,
            Email = request.Email,
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            Password = _passwordHasher.HashPassword(request.Password),
            PrivacyAccepted = request.PrivacyAccepted,
            AcceptanceDate = DateTime.UtcNow,
            ChangePasswordRequest = false,
            CountryId = request.CountryId,
            RoleId = userRole.RoleId,
            BranchId = request.BranchId,
            Active = true,
            DateCreatedTime = DateTime.UtcNow,
            CreateUser = request.UserId,
            DateUpdatedTime = DateTime.UtcNow
        };

        var createdUser = await _userRepository.AddAsync(newUser);
        await _userRepository.SaveChangesAsync();

        var response = new UserRegisteredResponse
        {
            UserId = createdUser.UserId,
            UserAccount = createdUser.UserAccount,
            Email = createdUser.Email,
            Name = createdUser.Name
        };

        return ApiResponse<UserRegisteredResponse>.CreatedResponse(
            response,
            "Usuario registrado exitosamente"
        );
    }

    public async Task<ApiResponse<CurrentUserResponse>> GetCurrentUserAsync(int userId)
    {
        var user = await _userRepository.GetByIdWithDetailsAsync(userId);

        if (user == null)
        {
            return ApiResponse<CurrentUserResponse>.NotFoundResponse("Usuario no encontrado");
        }

        var response = new CurrentUserResponse
        {
            UserId = user.UserId,
            UserAccount = user.UserAccount,
            Email = user.Email,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role.RoleCode,
            RoleDescription = user.Role.Description,
            CountryCode = user.Country.CountryCode,
            CountryName = user.Country.Description,
            BranchId = user.BranchId
        };

        return ApiResponse<CurrentUserResponse>.SuccessResponse(response);
    }
}