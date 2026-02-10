using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetEnterprise.Domain.Entities.Security;

namespace NetEnterprise.Infrastruture.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role", "Security");

        builder.HasKey(r => r.RoleId);

        builder.Property(r => r.RoleId)
            .HasColumnName("RoleId");

        builder.Property(r => r.BranchId)
            .HasColumnName("BranchId");

        builder.Property(r => r.RoleCode)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("RoleCode")
            .IsUnicode(false);

        builder.Property(r => r.Description)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Description")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        // Audit fields
        builder.Property(r => r.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(r => r.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(r => r.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(r => r.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(r => r.UpdateUser)
            .HasColumnName("UpdateUser");

        // Indexes
        builder.HasIndex(r => r.RoleCode)
            .IsUnique()
            .HasDatabaseName("IX_RoleCode");

        // Relationships
        builder.HasOne(r => r.Branch)
            .WithMany() // Sin Navegacion inversa
            .HasForeignKey(r => r.BranchId)
            .HasConstraintName("FK_Role_Branch")
            .OnDelete(DeleteBehavior.Restrict);
    }
}