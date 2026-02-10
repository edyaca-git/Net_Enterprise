using Microsoft.EntityFrameworkCore;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Domain.Entities.Management;
using NetEnterprise.Infrastruture.Persistence;

namespace NetEnterprise.Infrastruture.Repositories;

public class CompanyRepository : GenericRepository<Company, Guid>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByBusinessNameAsync(string businessName, Guid? excludeId = null)
    {
        return await _dbSet
            .Where(c => c.BusinessName == businessName && (excludeId == null || c.CompanyUid != excludeId))
            .AnyAsync();
    }

    public async Task<bool> ExistsByTaxIdAsync(string taxId, Guid? excludeId = null)
    {
        return await _dbSet
            .Where(c => c.TaxId == taxId && (excludeId == null || c.CompanyUid != excludeId))
            .AnyAsync();
    }
}