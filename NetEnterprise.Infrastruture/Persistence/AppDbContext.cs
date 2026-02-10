using Microsoft.EntityFrameworkCore;
using NetEnterprise.Domain.Entities.Catalog;
using NetEnterprise.Domain.Entities.Global;
using NetEnterprise.Domain.Entities.Management;
using NetEnterprise.Domain.Entities.Security;

namespace NetEnterprise.Infrastruture.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Security Schema
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    // Global Schema
    public DbSet<Country> Countries { get; set; }

    public DbSet<IndustryType> IndustryTypes { get; set; }

    // Catalog Schema
    public DbSet<Group> Groups { get; set; }

    public DbSet<SubGroup> SubGroups { get; set; }

    // Management Schema
    public DbSet<Company> Companies { get; set; }

    public DbSet<Branch> Branches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}