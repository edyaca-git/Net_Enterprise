using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetEnterprise.Domain.Entities.Catalog;

namespace NetEnterprise.Infrastruture.Persistence.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups", "Catalog");

        builder.HasKey(g => g.GroupId);

        builder.Property(g => g.GroupId)
            .HasColumnName("GroupId");

        builder.Property(g => g.BranchId)
            .HasColumnName("BranchId");

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Name")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        // Audit fields
        builder.Property(g => g.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(g => g.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(g => g.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(g => g.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(g => g.UpdateUser)
            .HasColumnName("UpdateUser");

        // Indexes
        builder.HasIndex(g => g.Name)
            .IsUnique()
            .HasDatabaseName("IX_Group_Name");

        // Relationships
        builder.HasOne(g => g.Branch)
            .WithMany() // Sin Navegacion inversa
            .HasForeignKey(g => g.BranchId)
            .HasConstraintName("FK_Group_Branch")
            .OnDelete(DeleteBehavior.Restrict);
    }
}