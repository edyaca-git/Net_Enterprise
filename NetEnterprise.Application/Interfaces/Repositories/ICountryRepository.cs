using NetEnterprise.Domain.Entities.Global;

namespace NetEnterprise.Application.Interfaces.Repositories;

public interface ICountryRepository : IGenericRepository<Country, int>
{
    Task<bool> ExistsByCodeAsync(string code, int? excludeId = null);

    Task<Country?> GetByCodeAsync(string code);
}