using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using NetEnterprise.Api;
using NetEnterprise.Api.Middleware;
using NetEnterprise.Api.Services;
using NetEnterprise.Application.DTOs.Branch;
using NetEnterprise.Application.DTOs.Company;
using NetEnterprise.Application.DTOs.Country;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Application.Interfaces.Services;
using NetEnterprise.Application.Mappings;
using NetEnterprise.Application.Services;
using NetEnterprise.Domain.Entities.Global;
using NetEnterprise.Domain.Entities.Management;
using NetEnterprise.Infrastruture.Persistence;
using NetEnterprise.Infrastruture.Persistence.Seeders;
using NetEnterprise.Infrastruture.Repositories;
using NetEnterprise.Infrastruture.Services;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Enterprise API",
        Version = "v1",
        Description = "API con Arquitectura Onion + DDD + EF Core",
        Contact = new OpenApiContact
        {
            Name = "NetEnterprise Team",
            Email = "support@netenterprise.com"
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese 'Bearer' [espacio] y luego su token JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Database configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("NetEnterprise.Infrastruture")
    )
);

// JWT Configuration
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettings);

var secretKey = jwtSettings.Get<JwtSettings>()!.SecretKey;
var key = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Get<JwtSettings>()!.Issuer,
        ValidAudience = jwtSettings.Get<JwtSettings>()!.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

//Todos tus Profiles están en Application/Mappings
//Todos viven en el mismo Assembly
//AutoMapper escanea y registra TODOS automáticamente
// AutoMapper

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Repositories
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//REGISTRO GENÉRICO (para entidades sin repository específico)
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

//Servicios de infraestructura
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

//Servicios de aplicación
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IGenericService<Country, CountryDto, int>, CountryService>();
builder.Services.AddScoped<IGenericService<Company, CompanyDto, Guid>, CompanyService>();
builder.Services.AddScoped<IGenericService<Branch, BranchDto, Guid>, GenericService<Branch, BranchDto, Guid>>();

//Token service
builder.Services.AddScoped<ITokenService, TokenService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Seed data - ACTUALIZADO
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();

        // Aplicar migraciones pendientes
        await context.Database.MigrateAsync();

        // Ejecutar seeders
        await DbSeeder.SeedAllAsync(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error al inicializar la base de datos");
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();