using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetEnterprise.Domain.Entities.Global;

namespace NetEnterprise.Infrastruture.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country", "Global");

        builder.HasKey(c => c.CountryId);

        builder.Property(c => c.CountryId)
            .HasColumnName("CountryId");

        builder.Property(c => c.CountryCode)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("CountryCode")
            .IsUnicode(false);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Description")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        builder.Property(c => c.UTCdiff)
            .HasColumnName("UTCdiff");

        builder.Property(c => c.LanguageId)
            .HasColumnName("LanguageId");

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
        builder.HasIndex(c => c.CountryCode)
            .IsUnique()
            .HasDatabaseName("IX_Country_CountryCode");
    }
}