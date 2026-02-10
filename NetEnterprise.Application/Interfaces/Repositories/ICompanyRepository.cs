using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Application.Interfaces.Repositories;

public interface ICompanyRepository : IGenericRepository<Company, Guid>
{
    Task<bool> ExistsByBusinessNameAsync(string businessName, Guid? excludeId = null);

    Task<bool> ExistsByTaxIdAsync(string taxId, Guid? excludeId = null);
}