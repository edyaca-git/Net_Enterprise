using Microsoft.EntityFrameworkCore;
using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Infrastruture.Persistence.Seeders
{
    public static class BranchSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (await context.Branches.AnyAsync())
            {
                return; // Ya existen Sucursales, no se realiza el seeding
            }
            var branches = new List<Branch>
                    {
                        new Branch
                        {
                            BranchUid = Guid.NewGuid(),
                            CompanyId = 1,

                            // Branch Information
                            Name = "Sucursal Principal",

                            CommercialName = "Sucursal Principal",
                            BranchTypeId = 1,

                            // Physical Address
                            AddressLine1 = "Calle Principal 123",

                            AddressLine2 = "Casa Grande",
                            AddressSuburb = "La Gsrita",
                            AddressCity = "Guadalajara",
                            AddressMunicipality = "Zapopan",
                            AddressState = "Jalisco",
                            AddressPostalCode = "45000",
                            AddressCountry = "México",

                            // Contact Information
                            TaxIdentificationNumber = "RFC123456789",
                            PhoneNumber = "333-123-4567",
                            SecondaryPhoneNumber = "333-987-6543",
                            EmailAddress = "edyaca@hotmail.com",
                            Website = "www.sucursalprincipal.com"
                        }
                    };

            context.Branches.AddRange(branches);
            context.SaveChanges();
            Console.WriteLine("Branches seeded successfully.");
        }
    }
}