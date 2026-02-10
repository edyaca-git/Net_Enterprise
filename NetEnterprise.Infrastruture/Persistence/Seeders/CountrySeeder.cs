using Microsoft.EntityFrameworkCore;
using NetEnterprise.Domain.Entities.Global;

namespace NetEnterprise.Infrastruture.Persistence.Seeders;

public static class CountrySeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Countries.AnyAsync())
        {
            return; // Ya existen países
        }

        var countries = new List<Country>
        {
            new Country
            {
                CountryCode = "MX",
                Description = "México",
                UTCdiff = -6,
                LanguageId = 1,
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new Country
            {
                CountryCode = "US",
                Description = "United States",
                UTCdiff = -5,
                LanguageId = 2,
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new Country
            {
                CountryCode = "CA",
                Description = "Canada",
                UTCdiff = -5,
                LanguageId = 2,
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new Country
            {
                CountryCode = "ES",
                Description = "España",
                UTCdiff = 1,
                LanguageId = 1,
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new Country
            {
                CountryCode = "CO",
                Description = "Colombia",
                UTCdiff = -5,
                LanguageId = 1,
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            },
            new Country
            {
                CountryCode = "AR",
                Description = "Argentina",
                UTCdiff = -3,
                LanguageId = 1,
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            }
        };

        await context.Countries.AddRangeAsync(countries);
        await context.SaveChangesAsync();

        Console.WriteLine("Países inicializados correctamente");
    }
}