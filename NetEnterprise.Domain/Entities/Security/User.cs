using NetEnterprise.Domain.Common;
using NetEnterprise.Domain.Entities.Global;
using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Domain.Entities.Security;

public class User : AuditableEntity
{
    public int UserId { get; set; }
    public int BranchId { get; set; }
    public string UserAccount { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Password { get; set; }
    public bool PrivacyAccepted { get; set; }
    public DateTime? AcceptanceDate { get; set; }
    public bool ChangePasswordRequest { get; set; } = true;
    public int CountryId { get; set; }
    public int RoleId { get; set; }
    public int? PrivacyPolicyId { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? Expiration { get; set; }
    public Guid? PasswordRecoveryToken { get; set; }
    public int? IncorrectPasswordAttempts { get; set; }
    public DateTime? BlockedToDate { get; set; }

    // Navigation properties
    public Branch Branch { get; set; } = null!;

    public Country Country { get; set; } = null!;
    public Role Role { get; set; } = null!;
}