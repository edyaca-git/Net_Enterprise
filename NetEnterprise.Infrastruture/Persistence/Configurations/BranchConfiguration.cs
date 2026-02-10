using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Infrastruture.Persistence.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches", "Management");

        builder.HasKey(b => b.BranchId);

        builder.Property(b => b.BranchId)
            .HasColumnName("BranchId")
            .ValueGeneratedOnAdd();

        builder.Property(b => b.BranchUid)
            .HasColumnName("BranchUid")
            .IsRequired();

        builder.Property(b => b.CompanyId)
            .IsRequired()
            .HasColumnName("CompanyId");

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("Name")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.CommercialName)
            .HasMaxLength(80)
            .HasColumnName("CommercialName")
            .IsUnicode(false);

        builder.Property(b => b.BranchTypeId)
            .HasColumnName("BranchTypeId");

        builder.Property(b => b.AddressLine1)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("AddressLine1")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressLine2)
            .HasMaxLength(200)
            .HasColumnName("AddressLine2")
            .IsUnicode(false);

        builder.Property(b => b.AddressSuburb)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("AddressSuburb")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressCity)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("AddressCity")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressMunicipality)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("AddressMunicipality")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressState)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("AddressState")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressPostalCode)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("AddressPostalCode")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressCountry)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("AddressCountry")
            .IsUnicode(false)
            .HasDefaultValue("México");

        builder.Property(b => b.TaxIdentificationNumber)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("TaxIdentificationNumber")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.PhoneNumber)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("PhoneNumber")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.SecondaryPhoneNumber)
            .HasMaxLength(50)
            .HasColumnName("SecondaryPhoneNumber")
            .IsUnicode(false);

        builder.Property(b => b.EmailAddress)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("EmailAddress")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.Website)
            .HasMaxLength(100)
            .HasColumnName("Website")
            .IsUnicode(false);

        // Audit fields
        builder.Property(b => b.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(b => b.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(b => b.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(b => b.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(b => b.UpdateUser)
            .HasColumnName("UpdateUser");

        // Indexes
        builder.HasIndex(b => b.BranchUid)
            .IsUnique()
            .HasDatabaseName("IX_Branches_BranchUid");

        builder.HasIndex(b => b.CompanyId)
            .HasDatabaseName("IX_Branches_CompanyId");

        // Relationships
        builder.HasOne(b => b.Company)
            .WithMany(c => c.Branches)
            .HasForeignKey(b => b.CompanyId)
            .HasConstraintName("FK_Branches_Companies")
            .OnDelete(DeleteBehavior.Restrict);
    }
}