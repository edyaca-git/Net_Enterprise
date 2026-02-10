using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Application.Interfaces.Repositories;

public interface IBranchRepository : IGenericRepository<Branch, int>
{
    Task<IEnumerable<Branch>> GetByCompanyIdAsync(int companyId);
}