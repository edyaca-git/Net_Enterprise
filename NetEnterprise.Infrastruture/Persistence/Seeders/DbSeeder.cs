namespace NetEnterprise.Infrastruture.Persistence.Seeders;

//ORQUESTADOR
//patrón de seeding (o "semilla de datos") es una práctica común en el
//desarrollo con Entity Framework Core (EF Core) para insertar datos
//iniciales en la base de datos de manera automática y controlada.
public static class DbSeeder
{
    public static async Task SeedAllAsync(AppDbContext context)
    {
        Console.WriteLine("🌱 Iniciando proceso de inicialización de datos...");
        Console.WriteLine();

        // Orden importante: primero las tablas sin dependencias
        await CountrySeeder.SeedAsync(context);
        await IndustryTypeSeeder.SeedAsync(context);

        await CompanySeeder.SeedAsync(context);
        await BranchSeeder.SeedAsync(context);

        await RoleSeeder.SeedAsync(context);

        // comento las demas por queno quiero que se llenen

        // Luego las tablas que dependen de otras
        //await AdminUserSeeder.SeedAsync(context);

        Console.WriteLine();
        Console.WriteLine("Proceso de inicialización completado");
        Console.WriteLine("═══════════════════════════════════════════");
    }
}