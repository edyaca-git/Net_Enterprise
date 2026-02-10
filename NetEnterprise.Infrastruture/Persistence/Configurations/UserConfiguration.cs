using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetEnterprise.Domain.Entities.Security;

namespace NetEnterprise.Infrastruture.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", "Security");

        builder.HasKey(u => u.UserId);

        builder.Property(u => u.UserId)
            .HasColumnName("UserId");

        builder.Property(u => u.BranchId)
            .IsRequired()
            .HasColumnName("BranchId");

        builder.Property(u => u.UserAccount)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("UserAccount")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Email")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Name")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("PhoneNumber")
            .IsUnicode(false);

        builder.Property(u => u.Password)
            .HasMaxLength(250)
            .HasColumnName("Password")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        builder.Property(u => u.PrivacyAccepted)
            .IsRequired()
            .HasColumnName("PrivacyAccepted")
            .HasDefaultValue(false);

        builder.Property(u => u.AcceptanceDate)
            .HasColumnName("AcceptanceDate");

        builder.Property(u => u.ChangePasswordRequest)
            .IsRequired()
            .HasColumnName("ChangePasswordRequest")
            .HasDefaultValue(true);

        builder.Property(u => u.CountryId)
            .IsRequired()
            .HasColumnName("CountryId");

        builder.Property(u => u.RoleId)
            .IsRequired()
            .HasColumnName("RoleId");

        builder.Property(u => u.PrivacyPolicyId)
            .HasColumnName("PrivacyPolicyId");

        builder.Property(u => u.CreatedBy)
            .HasColumnName("CreatedBy");

        builder.Property(u => u.UpdatedBy)
            .HasColumnName("UpdatedBy");

        builder.Property(u => u.RefreshToken)
            .HasMaxLength(255)
            .HasColumnName("RefreshToken")
            .IsUnicode(false);

        builder.Property(u => u.Expiration)
            .HasColumnName("Expiration");

        builder.Property(u => u.PasswordRecoveryToken)
            .HasColumnName("PasswordRecoveryToken");

        builder.Property(u => u.IncorrectPasswordAttempts)
            .HasColumnName("IncorrectPasswordAttempts");

        builder.Property(u => u.BlockedToDate)
            .HasColumnName("BlockedToDate");

        // Audit fields
        builder.Property(u => u.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(u => u.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(u => u.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(u => u.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(u => u.UpdateUser)
            .HasColumnName("UpdateUser");

        // Indexes
        builder.HasIndex(u => u.UserAccount)
            .IsUnique()
            .HasDatabaseName("IX_User_UserAccount");

        builder.HasIndex(u => u.BranchId)
            .HasDatabaseName("IX_User_BranchId");

        // Relationships
        builder.HasOne(u => u.Branch)
            .WithMany() // Sin Navegacion inversa
            .HasForeignKey(u => u.BranchId)
            .HasConstraintName("FK_User_Branch")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .HasConstraintName("FK_User_Role")
            .OnDelete(DeleteBehavior.Restrict);
    }
}