using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetEnterprise.Domain.Entities.Global;

namespace NetEnterprise.Infrastruture.Persistence.Configurations;

public class IndustryTypeConfiguration : IEntityTypeConfiguration<IndustryType>
{
    public void Configure(EntityTypeBuilder<IndustryType> builder)
    {
        builder.ToTable("IndustryTypes", "Global");

        builder.HasKey(i => i.IndustryTypeId);

        builder.Property(i => i.IndustryTypeId)
            .HasColumnName("IndustryTypeId");

        builder.Property(i => i.IndustryCode)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("IndustryCode")
            .IsUnicode(false);

        builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Description")
            .IsUnicode(false);

        // Audit fields
        builder.Property(i => i.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(i => i.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(i => i.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(i => i.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(i => i.UpdateUser)
            .HasColumnName("UpdateUser");
    }
}