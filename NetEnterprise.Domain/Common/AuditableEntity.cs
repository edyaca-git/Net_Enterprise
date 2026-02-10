namespace NetEnterprise.Domain.Common;

public abstract class AuditableEntity
{
    public bool Active { get; set; } = true;
    public DateTime DateCreatedTime { get; set; } = DateTime.UtcNow;
    public int CreateUser { get; set; }
    public DateTime DateUpdatedTime { get; set; } = DateTime.UtcNow;
    public int? UpdateUser { get; set; }
}