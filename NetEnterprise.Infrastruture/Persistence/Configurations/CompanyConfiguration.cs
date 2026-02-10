using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Infrastruture.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies", "Management");

        builder.HasKey(c => c.CompanyId);

        builder.Property(c => c.CompanyId)
            .HasColumnName("CompanyId")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.CompanyUid)
            .HasColumnName("CompanyUid")
            .IsRequired();

        builder.Property(c => c.BusinessName)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("BusinessName")
            .IsUnicode(false);

        builder.Property(c => c.Street)
            .HasMaxLength(80)
            .HasColumnName("Street")
            .IsUnicode(false);

        builder.Property(c => c.ExteriorNumber)
            .HasMaxLength(20)
            .HasColumnName("ExteriorNumber")
            .IsUnicode(false);

        builder.Property(c => c.InteriorNumber)
            .HasMaxLength(20)
            .HasColumnName("InteriorNumber")
            .IsUnicode(false);

        builder.Property(c => c.Neighborhood)
            .HasMaxLength(80)
            .HasColumnName("Neighborhood")
            .IsUnicode(false);

        builder.Property(c => c.Locality)
            .HasMaxLength(80)
            .HasColumnName("Locality")
            .IsUnicode(false);

        builder.Property(c => c.Municipality)
            .HasMaxLength(80)
            .HasColumnName("Municipality")
            .IsUnicode(false);

        builder.Property(c => c.State)
            .HasMaxLength(80)
            .HasColumnName("State")
            .IsUnicode(false);

        builder.Property(c => c.ZipCode)
            .HasMaxLength(20)
            .HasColumnName("ZipCode")
            .IsUnicode(false);

        builder.Property(c => c.Country)
            .HasMaxLength(80)
            .HasColumnName("Country")
            .IsUnicode(false);

        builder.Property(c => c.TaxId)
            .HasMaxLength(20)
            .HasColumnName("TaxId")
            .IsRequired()
            .IsUnicode(false);

        builder.Property(c => c.PrimaryPhone)
            .HasMaxLength(15)
            .HasColumnName("PrimaryPhone")
            .IsUnicode(false);

        builder.Property(c => c.SecondaryPhone)
            .HasMaxLength(15)
            .HasColumnName("SecondaryPhone")
            .IsUnicode(false);

        builder.Property(c => c.ErpSystemCode)
            .HasMaxLength(80)
            .HasColumnName("ErpSystemCode")
            .IsUnicode(false);

        builder.Property(c => c.IndustryTypeId)
            .HasColumnName("IndustryTypeId");

        builder.Property(c => c.CompanyTitle)
            .HasMaxLength(280)
            .HasColumnName("CompanyTitle")
            .IsUnicode(false);

        builder.Property(c => c.LegacyRecordId)
            .HasColumnName("LegacyRecordId");

        // Audit fields
        builder.Property(c => c.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(c => c.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(c => c.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(c => c.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(c => c.UpdateUser)
            .HasColumnName("UpdateUser");

        // Indexes
        builder.HasIndex(c => c.CompanyUid)
            .IsUnique()
            .HasDatabaseName("IX_Companies_CompanyUid");

        builder.HasIndex(c => c.BusinessName)
            .IsUnique()
            .HasDatabaseName("UQ_Companies_BusinessName");

        builder.HasIndex(c => c.TaxId)
            .IsUnique()
            .HasDatabaseName("UQ_Companies_TaxId");

        // Relationships
    }
}