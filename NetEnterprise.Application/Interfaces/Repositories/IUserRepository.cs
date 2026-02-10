using NetEnterprise.Domain.Entities.Security;

namespace NetEnterprise.Application.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User, int>
{
    Task<User?> GetByUserAccountAsync(string userAccount);

    Task<User?> GetByEmailAsync(string email);

    Task<bool> ExistsByUserAccountAsync(string userAccount, int? excludeId = null);

    Task<bool> ExistsByEmailAsync(string email, int? excludeId = null);

    Task<User?> GetByIdWithDetailsAsync(int userId);

    Task IncrementFailedLoginAttemptsAsync(int userId);

    Task ResetFailedLoginAttemptsAsync(int userId);

    Task BlockUserAsync(int userId, DateTime blockedUntil);
}