using NetEnterprise.Domain.Entities.Security;

namespace NetEnterprise.Application.Interfaces.Repositories;

public interface IRoleRepository : IGenericRepository<Role, int>
{
    Task<bool> ExistsByCodeAsync(string code, int? excludeId = null);

    Task<Role?> GetByCodeAsync(string code);
}