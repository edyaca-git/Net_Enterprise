using Microsoft.EntityFrameworkCore;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Domain.Entities.Global;
using NetEnterprise.Infrastruture.Persistence;

namespace NetEnterprise.Infrastruture.Repositories;

public class CountryRepository : GenericRepository<Country, int>, ICountryRepository
{
    public CountryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByCodeAsync(string code, int? excludeId = null)
    {
        return await _dbSet
            .Where(c => c.CountryCode == code && (excludeId == null || c.CountryId != excludeId))
            .AnyAsync();
    }

    public async Task<Country?> GetByCodeAsync(string code)
    {
        return await _dbSet
            .FirstOrDefaultAsync(c => c.CountryCode == code);
    }
}