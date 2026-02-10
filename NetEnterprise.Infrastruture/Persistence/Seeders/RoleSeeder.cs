using Microsoft.EntityFrameworkCore;
using NetEnterprise.Domain.Entities.Security;

namespace NetEnterprise.Infrastruture.Persistence.Seeders;

public static class RoleSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Roles.AnyAsync())
        {
            return; // Ya existen roles
        }

        var roles = new List<Role>
        {
            new Role
            {
                RoleCode = "ADMIN",
                BranchId = 1,
                Description = "Administrador del sistema - Acceso total",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new Role
            {
                RoleCode = "MANAGER",
                BranchId = 1,
                Description = "Gerente - Acceso a gestión y reportes",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new Role
            {
                RoleCode = "USER",
                BranchId = 1,
                Description = "Usuario regular - Acceso básico",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            }
        };

        await context.Roles.AddRangeAsync(roles);
        await context.SaveChangesAsync();

        Console.WriteLine("Roles inicializados correctamente");
    }
}