using Microsoft.EntityFrameworkCore;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Domain.Entities.Security;
using NetEnterprise.Infrastruture.Persistence;

namespace NetEnterprise.Infrastruture.Repositories;

public class UserRepository : GenericRepository<User, int>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUserAccountAsync(string userAccount)
    {
        return await _dbSet
            .Include(u => u.Role)
            .Include(u => u.Country)
            .FirstOrDefaultAsync(u => u.UserAccount == userAccount);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet
            .Include(u => u.Role)
            .Include(u => u.Country)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> ExistsByUserAccountAsync(string userAccount, int? excludeId = null)
    {
        return await _dbSet
            .Where(u => u.UserAccount == userAccount && (excludeId == null || u.UserId != excludeId))
            .AnyAsync();
    }

    public async Task<bool> ExistsByEmailAsync(string email, int? excludeId = null)
    {
        return await _dbSet
            .Where(u => u.Email == email && (excludeId == null || u.UserId != excludeId))
            .AnyAsync();
    }

    public async Task<User?> GetByIdWithDetailsAsync(int userId)
    {
        return await _dbSet
            .Include(u => u.Role)
            .Include(u => u.Country)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task IncrementFailedLoginAttemptsAsync(int userId)
    {
        var user = await _dbSet.FindAsync(userId);
        if (user != null)
        {
            user.IncorrectPasswordAttempts = (user.IncorrectPasswordAttempts ?? 0) + 1;
            user.DateUpdatedTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    public async Task ResetFailedLoginAttemptsAsync(int userId)
    {
        var user = await _dbSet.FindAsync(userId);
        if (user != null)
        {
            user.IncorrectPasswordAttempts = 0;
            user.BlockedToDate = null;
            user.DateUpdatedTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    public async Task BlockUserAsync(int userId, DateTime blockedUntil)
    {
        var user = await _dbSet.FindAsync(userId);
        if (user != null)
        {
            user.BlockedToDate = blockedUntil;
            user.DateUpdatedTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}