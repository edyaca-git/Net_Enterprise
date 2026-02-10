using Microsoft.EntityFrameworkCore;
using NetEnterprise.Domain.Entities.Global;

namespace NetEnterprise.Infrastruture.Persistence.Seeders;

public static class IndustryTypeSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.IndustryTypes.AnyAsync())
        {
            return; // Ya existen tipos de industria
        }

        var industryTypes = new List<IndustryType>
        {
            new IndustryType
            {
                IndustryCode = "TECH",
                Description = "Tecnología e Informática",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new IndustryType
            {
                IndustryCode = "RETAIL",
                Description = "Comercio al por menor",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new IndustryType
            {
                IndustryCode = "MANUF",
                Description = "Manufactura",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new IndustryType
            {
                IndustryCode = "FINANCE",
                Description = "Servicios Financieros",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new IndustryType
            {
                IndustryCode = "HEALTH",
                Description = "Salud y Servicios Médicos",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new IndustryType
            {
                IndustryCode = "FOOD",
                Description = "Alimentos y Bebidas",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new IndustryType
            {
                IndustryCode = "CONSTR",
                Description = "Construcción",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new IndustryType
            {
                IndustryCode = "EDUC",
                Description = "Educación",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new IndustryType
            {
                IndustryCode = "TRANSP",
                Description = "Transporte y Logística",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new IndustryType
            {
                IndustryCode = "OTHER",
                Description = "Otros",
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            }
        };

        await context.IndustryTypes.AddRangeAsync(industryTypes);
        await context.SaveChangesAsync();

        Console.WriteLine("Tipos de industria inicializados correctamente");
    }
}