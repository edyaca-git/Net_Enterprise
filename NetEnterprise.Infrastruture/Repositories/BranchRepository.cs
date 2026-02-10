using Microsoft.EntityFrameworkCore;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Domain.Entities.Management;
using NetEnterprise.Infrastruture.Persistence;

namespace NetEnterprise.Infrastruture.Repositories;

public class BranchRepository : GenericRepository<Branch, int>, IBranchRepository
{
    public BranchRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Branch>> GetByCompanyIdAsync(int companyId)
    {
        return await _dbSet
            .Where(b => b.CompanyId == companyId)
            .ToListAsync();
    }
}