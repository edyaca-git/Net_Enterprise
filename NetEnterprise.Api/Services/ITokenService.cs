using NetEnterprise.Domain.Entities.Security;

namespace NetEnterprise.Api.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}