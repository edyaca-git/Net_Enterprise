using Microsoft.EntityFrameworkCore;
using NetEnterprise.Domain.Entities.Security;
using System.Security.Cryptography;
using System.Text;

namespace NetEnterprise.Infrastruture.Persistence.Seeders;

public static class AdminUserSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Users.AnyAsync())
        {
            return; // Ya existen usuarios
        }

        // Obtener Role ADMIN y Country México
        var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.RoleCode == "ADMIN");
        var mexicoCountry = await context.Countries.FirstOrDefaultAsync(c => c.CountryCode == "MX");

        if (adminRole == null || mexicoCountry == null)
        {
            Console.WriteLine("No se puede crear usuario admin: faltan roles o países");
            return;
        }

        var adminUser = new User
        {
            UserAccount = "admin",
            Email = "admin@empresa.com",
            Name = "Administrador del Sistema",
            PhoneNumber = "5551234567",
            Password = HashPassword("Admin123!"),
            PrivacyAccepted = true,
            AcceptanceDate = DateTime.UtcNow,
            ChangePasswordRequest = false,
            CountryId = mexicoCountry.CountryId,
            RoleId = adminRole.RoleId,
            Active = true,
            DateCreatedTime = DateTime.UtcNow,
            CreateUser = 1,
            DateUpdatedTime = DateTime.UtcNow
        };

        await context.Users.AddAsync(adminUser);
        await context.SaveChangesAsync();

        Console.WriteLine("Usuario administrador creado correctamente");
        Console.WriteLine("Email: admin@empresa.com");
        Console.WriteLine("Password: Admin123!");
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}