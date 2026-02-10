using Microsoft.EntityFrameworkCore;
using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Infrastruture.Persistence.Seeders;

public static class CompanySeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Companies.AnyAsync())
        {
            return; // Ya existen Companies, no se realiza el seeding
        }

        var Companies = new List<Company>
        {
            new Company
            {
                CompanyUid = Guid.NewGuid(),
                BusinessName = "Tech Solutions S.A.",
                 // Address
                Street = "123 Tech Street",
                ExteriorNumber = "456",
                InteriorNumber = "A",
                Neighborhood = "Tech Park",
                Locality = "Tech City",
                Municipality = "Tech Municipality",
                State = "Tech State",
                ZipCode = "12345",
                Country = "México",
                // Fiscal & Contact
                TaxId = "KMKE112611PS3",
                PrimaryPhone = "555-1234",
                SecondaryPhone = "555-5678",
                // System info
                ErpSystemCode = "ERP001",
                IndustryTypeId = 1,
                CompanyTitle = "Tech Solutions - Innovating the Future",
                LegacyRecordId = 1
}
        };

        await context.Companies.AddRangeAsync(Companies);
        await context.SaveChangesAsync();

        Console.WriteLine("Datos de empresas sembrados correctamente.");
    }
}