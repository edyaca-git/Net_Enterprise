using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetEnterprise.Domain.Entities.Catalog;

namespace NetEnterprise.Infrastruture.Persistence.Configurations;

public class SubGroupConfiguration : IEntityTypeConfiguration<SubGroup>
{
    public void Configure(EntityTypeBuilder<SubGroup> builder)
    {
        builder.ToTable("SubGroups", "Catalog");

        builder.HasKey(s => s.SubGroupId);

        builder.Property(s => s.SubGroupId)
            .HasColumnName("SubGroupId");

        builder.Property(s => s.GroupId)
            .IsRequired()
            .HasColumnName("GroupId");

        builder.Property(s => s.BranchId)
            .HasColumnName("BranchId");

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Name")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        // Audit fields
        builder.Property(s => s.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(s => s.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(s => s.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(s => s.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(s => s.UpdateUser)
            .HasColumnName("UpdateUser");

        // Indexes
        builder.HasIndex(s => s.Name)
            .IsUnique()
            .HasDatabaseName("IX_Group_Name");

        // Relationships
        builder.HasOne(s => s.Group)
            .WithMany(g => g.SubGroups)
            .HasForeignKey(s => s.GroupId)
            .HasConstraintName("FK_SubGroups_Groups_GroupId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(g => g.Branch)
            .WithMany() // Sin Navegacion inversa
            .HasForeignKey(g => g.BranchId)
            .HasConstraintName("FK_SubGroups_Branch")
            .OnDelete(DeleteBehavior.Restrict);
    }
}