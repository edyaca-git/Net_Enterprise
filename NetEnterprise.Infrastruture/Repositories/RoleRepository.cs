using Microsoft.EntityFrameworkCore;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Domain.Entities.Security;
using NetEnterprise.Infrastruture.Persistence;

namespace NetEnterprise.Infrastruture.Repositories;

public class RoleRepository : GenericRepository<Role, int>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByCodeAsync(string code, int? excludeId = null)
    {
        return await _dbSet
            .Where(r => r.RoleCode == code && (excludeId == null || r.RoleId != excludeId))
            .AnyAsync();
    }

    public async Task<Role?> GetByCodeAsync(string code)
    {
        return await _dbSet
            .FirstOrDefaultAsync(r => r.RoleCode == code);
    }
}