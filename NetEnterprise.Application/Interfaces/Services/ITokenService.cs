using NetEnterprise.Domain.Entities.Security;

namespace NetEnterprise.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}