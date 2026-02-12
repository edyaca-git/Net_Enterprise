
🎯 SOLUCIÓN COMPLETA .NET CORE 8 - ARQUITECTURA ONION + DDD + EF CORE
Voy a darte TODOS LOS PASOS completos sin omitir nada. Este será un documento extenso y detallado.
```text
src/
├── `NetEnterprise.sln`
├── `NetEnterprise.Api/`
│   ├── `NetEnterprise.Api.csproj`
│   ├── `Program.cs`
│   ├── `appsettings.json`
│   └── `Middleware/`
│       └── `ExceptionMiddleware.cs`
│   └── `Controllers/`
│       ├── `AuthController.cs`
│       ├── `GenericController.cs`
│       ├── `BranchesController.cs`
│       ├── `CountriesController.cs`
│       └── `CompaniesController.cs`
│
├── `NetEnterprise.Application/`
│   ├── `NetEnterprise.Application.csproj`
│   ├── `Mappings/`
│   │   └── `MappingProfile.cs`
│   ├── `Interfaces/`
│   │   ├── `Services/`
│   │   │   ├── `IAuthService.cs`
│   │   │   ├── `IGenericService.cs`
│   │   │   ├── `IPasswordHasher.cs`
│   │   │   └── `ITokenService.cs`
│   │   └── `Repositories/`
│   │       ├── `IGenericRepository.cs`
│   │       ├── `ICountryRepository.cs`
│   │       ├── `IRoleRepository.cs`
│   │       ├── `ICompanyRepository.cs`
│   │       ├── `IBranchRepository.cs`
│   │       └── `IUserRepository.cs`
│   ├── `Services/`
│   │   ├── `AuthService.cs`
│   │   ├── `GenericService.cs`
│   │   ├── `CountryService.cs`
│   │   ├── `CompanyService.cs`
│   │   └── `TokenService.cs`
│   └── `DTOs/`
│       ├── `User/`
│       │   ├── `RegisterUserDto.cs`
│       │   ├── `LoginRequest.cs`
│       │   ├── `LoginResponse.cs`
│       │   ├── `UserRegisteredResponse.cs`
│       │   └── `CurrentUserResponse.cs`
│       ├── `Country/`
│       │   ├── `CountryDto.cs`
│       │   ├── `CreateCountryDto.cs`
│       │   └── `UpdateCountryDto.cs`
│       ├── `Role/`
│       │   ├── `RoleDto.cs`
│       │   ├── `CreateRoleDto.cs`
│       │   └── `UpdateRoleDto.cs`
│       ├── `Company/`
│       │   ├── `CompanyDto.cs`
│       │   ├── `CreateCompanyDto.cs`
│       │   └── `UpdateCompanyDto.cs`
│       └── `Branch/`
│           ├── `BranchDto.cs`
│           ├── `CreateBranchDto.cs`
│           └── `UpdateBranchDto.cs`
│
├── `NetEnterprise.Infrastruture/`    ← name preserved from repo
│   ├── `NetEnterprise.Infrastruture.csproj`
│   ├── `Authentication/` (referenced in Program)
│   │   └── *(JwtSettings may be in `NetEnterprise.Shared/Settings`)*
│   ├── `Persistence/`
│   │   ├── `AppDbContext.cs`
│   │   ├── `AppDbContextFactory.cs`
│   │   ├── `Migrations/`
│   │   │   ├── `20260207222913_PrimerEntidad.cs`
│   │   │   ├── `20260209202308_Borre_dbmanual_crear_de_nuevo.cs`
│   │   │   └── `20260209210935_PrimerEntidades.cs`
│   │   ├── `Configurations/`
│   │   │   ├── `UserConfiguration.cs`
│   │   │   ├── `GroupConfiguration.cs`
│   │   │   ├── `CompanyConfiguration.cs`
│   │   │   ├── `SubGroupConfiguration.cs`
│   │   │   ├── `BranchConfiguration.cs`
│   │   │   ├── `CountryConfiguration.cs`
│   │   │   ├── `IndustryTypeConfiguration.cs`
│   │   │   └── `RoleConfiguration.cs`
│   │   └── `Seeders/`
│   │       ├── `DbSeeder.cs`
│   │       ├── `RoleSeeder.cs`
│   │       ├── `CountrySeeder.cs`
│   │       ├── `IndustryTypeSeeder.cs`
│   │       ├── `AdminUserSeeder.cs`
│   │       ├── `CompanySeeder.cs`
│   │       └── `BranchSeeder.cs`
│   ├── `Repositories/`
│   │   ├── `GenericRepository.cs`
│   │   ├── `UserRepository.cs`
│   │   ├── `CountryRepository.cs`
│   │   ├── `RoleRepository.cs`
│   │   ├── `CompanyRepository.cs`
│   │   └── `BranchRepository.cs`
│   └── `Services/`
│       └── `PasswordHasher.cs`
│
├── `NetEnterprise.Domain/`
│   ├── `NetEnterprise.Domain.csproj`
│   ├── `Common/`
│   │   └── `AuditableEntity.cs`
│   ├── `Constants/`
│   │   └── `Roles.cs`
│   └── `Entities/`
│       ├── `Catalog/`
│       │   ├── `Group.cs`
│       │   ├── `SubGroup.cs`
│       │   ├── `IndustryType.cs`
│       │   └── `Country.cs`
│       ├── `Global/`
│       │   ├── `Country.cs`
│       │   └── `IndustryType.cs`
│       ├── `Management/`
│       │   ├── `Company.cs`
│       │   └── `Branch.cs`
│       └── `Security/`
│           ├── `User.cs`
│           └── `Role.cs`
│
└── `NetEnterprise.Shared/`
    ├── `NetEnterprise.Shared.csproj`
    ├── `Common/`
    │   ├── `PagedResult.cs`
    │   ├── `Metadata.cs`
    │   └── `ApiResponse.cs`
    ├── `DTOs/`
    │   └── `PaginationDto.cs`
    └── `Settings/`
        └── `JwtSettings.cs`
________________________________________
📋 ÍNDICE DE LA SOLUCIÓN
1.	Creación de la estructura de proyectos
2.	Configuración de referencias entre proyectos
3.	Domain Layer (Entidades, Value Objects, Enums)
4.	Shared Layer (DTOs, ApiResponse, Utilities)
5.	Application Layer (Interfaces, Services, DTOs, Mappings)
6.	Infrastructure Layer (DbContext, Repositories, Configurations)
7.	API Layer (Controllers, Middleware, JWT, Program.cs)
8.	Migraciones y Base de Datos
9.	Configuración completa
________________________________________
PARTE 1: CREACIÓN DE LA ESTRUCTURA DE PROYECTOS
Paso 1.1: Crear la Solution en Visual Studio 2022
1.	Abre Visual Studio 2022
2.	Click en "Create a new project"
3.	Busca "Blank Solution"
4.	Name: EnterpriseSolution
5.	Location: Elige tu carpeta
6.	Click "Create"
Paso 1.2: Crear el proyecto Domain
1.	Click derecho en la Solution → Add → New Project
2.	Busca "Class Library" (.NET 8)
3.	Name: Domain
4.	Location: Dentro de la carpeta de la solution
5.	Framework: .NET 8.0
6.	Click "Create"
7.	Elimina el archivo Class1.cs que se crea por defecto
Paso 1.3: Crear el proyecto Shared
1.	Click derecho en la Solution → Add → New Project
2.	Busca "Class Library" (.NET 8)
3.	Name: Shared
4.	Framework: .NET 8.0
5.	Click "Create"
6.	Elimina el archivo Class1.cs
Paso 1.4: Crear el proyecto Application
1.	Click derecho en la Solution → Add → New Project
2.	Busca "Class Library" (.NET 8)
3.	Name: Application
4.	Framework: .NET 8.0
5.	Click "Create"
6.	Elimina el archivo Class1.cs
Paso 1.5: Crear el proyecto Infrastructure
1.	Click derecho en la Solution → Add → New Project
2.	Busca "Class Library" (.NET 8)
3.	Name: Infrastructure
4.	Framework: .NET 8.0
5.	Click "Create"
6.	Elimina el archivo Class1.cs
Paso 1.6: Crear el proyecto API
1.	Click derecho en la Solution → Add → New Project
2.	Busca "ASP.NET Core Web API" (.NET 8)
3.	Name: API
4.	Framework: .NET 8.0
5.	Authentication type: None (lo haremos manual)
6.	Desmarcar "Use controllers" (usaremos controllers)
7.	Desmarcar "Enable OpenAPI support" (lo agregaremos después)
8.	Click "Create"
________________________________________
PARTE 2: CONFIGURACIÓN DE REFERENCIAS ENTRE PROYECTOS
Paso 2.1: Referencias del proyecto API
1.	Click derecho en API → Add → Project Reference
2.	Selecciona:
•	✅ Application
•	✅ Infrastructure
•	✅ Shared
3.	Click OK
Paso 2.2: Referencias del proyecto Infrastructure
1.	Click derecho en Infrastructure → Add → Project Reference
2.	Selecciona:
•	✅ Application
•	✅ Domain
•	✅ Shared
3.	Click OK
Paso 2.3: Referencias del proyecto Application
1.	Click derecho en Application → Add → Project Reference
2.	Selecciona:
•	✅ Domain
•	✅ Shared
3.	Click OK
Paso 2.4: Referencias del proyecto Domain
NO agregar referencias - Domain es independiente excepto de tipos base de .NET
Paso 2.5: Instalar paquetes NuGet
En el proyecto Domain:
(ninguno por ahora)
En el proyecto Shared:
1.	Click derecho en Shared → Manage NuGet Packages
2.	Click en Browse
3.	Instala:
•	Microsoft.AspNetCore.Http.Abstractions (versión 8.0.x)
En el proyecto Application:
1.	Click derecho en Application → Manage NuGet Packages
2.	Instala:
•	AutoMapper (versión 13.x)
•	FluentValidation (versión 11.x)
¿Para qué sirve FluentValidation?
•	Validar modelos de entrada: asegura que los datos que llegan a tus APIs o formularios cumplen ciertas reglas (ej. que un campo no esté vacío, que un email sea válido, que una edad esté en un rango).
•	Separar la lógica de validación: en lugar de poner if dentro de controladores, defines reglas en clases específicas.
•	Reutilizar validaciones: puedes aplicar las mismas reglas en distintos puntos de tu aplicación.
•	Integración con ASP.NET Core: se conecta fácilmente con el pipeline de validación de modelos, reemplazando o complementando DataAnnotations.

En el proyecto Infrastructure:
1.	Click derecho en Infrastructure → Manage NuGet Packages
2.	Instala:
•	Microsoft.EntityFrameworkCore (versión 8.0.x)
•	Microsoft.EntityFrameworkCore.Design  (versión 8.0.x)
•	Microsoft.EntityFrameworkCore.SqlServer (versión 8.0.x)
•	Microsoft.EntityFrameworkCore.Tools (versión 8.0.x)
•	Microsoft.Extensions.Configuration.Json (version 8.0.0)
En el proyecto API:
1.	Click derecho en API → Manage NuGet Packages
2.	Instala:
•	Microsoft.AspNetCore.Authentication.JwtBearer (versión 8.0.x)
•	Microsoft.EntityFrameworkCore.Design (versión 8.0.x)
•	Swashbuckle.AspNetCore (versión 6.5.x)
📌 ¿Para qué sirve?
•	Generar documentación automática de tus endpoints REST.
•	Explorador interactivo: Swagger UI te da una página web donde puedes probar tus endpoints sin necesidad de Postman o curl.
•	Definir contratos claros: expone los modelos de entrada/salida y los códigos de respuesta.
•	Facilitar integración: otros equipos pueden consumir tu API conociendo exactamente qué espera y qué devuelve.
•	Soporte para OpenAPI: genera especificaciones en formato estándar que puedes exportar y usar en otras herramientas.
•	AutoMapper (versión 13.x)
________________________________________
PARTE 3: DOMAIN LAYER
Paso 3.1: Crear estructura de carpetas en Domain
1.	Click derecho en Domain → Add → New Folder → Nombre: Entities
2.	Crear subcarpetas dentro de Entities:
•	Security
•	Catalog
•	Management
3.	Click derecho en Domain → Add → New Folder → Nombre: Common
4.	Click derecho en Domain → Add → New Folder → Nombre: Enums
5.	Click derecho en Domain → Add → New Folder → Nombre: Constants
Paso 3.2: Crear clase base AuditableEntity
1.	Click derecho en Domain/Common → Add → Class
2.	Name: AuditableEntity.cs
3.	Click Add
csharp
namespace Domain.Common;

public abstract class AuditableEntity
{
    public bool Active { get; set; } = true;
    public DateTime DateCreatedTime { get; set; } = DateTime.UtcNow;
    public int CreateUser { get; set; }
    public DateTime DateUpdatedTime { get; set; } = DateTime.UtcNow;
    public int? UpdateUser { get; set; }
}
Paso 3.3: Crear clase base AuditableEntityWithGuid
•	NO se va a hacer ya que se sugirió por confusion
Paso 3.4: Crear constantes de Roles
1.	Click derecho en Domain/Constants → Add → Class
2.	Name: Roles.cs
csharp
namespace Domain.Constants;

public static class Roles
{
    public const string Admin = "ADMIN";
    public const string Manager = "MANAGER";
    public const string User = "USER";
}
Paso 3.5: Crear entidad Role
1.	Click derecho en Domain/Entities/Security → Add → Class
2.	Name: Role.cs
csharp
using Domain.Common;

namespace Domain.Entities.Security;

public class Role : AuditableEntity
{
    public int RoleId { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? BranchId { get; set; }
    public string RoleCode { get; set; } = null!;
    public string Description { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
Paso 3.6: Crear entidad Country
1.	Click derecho en Domain/Entities/Catalog → Add → Class
2.	Name: Country.cs
csharp
using Domain.Common;

namespace Domain.Entities.Catalog;

public class Country : AuditableEntity
{
    public int CountryId { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? BranchId { get; set; }
    public string CountryCode { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? UTCdiff { get; set; }
    public int? LanguageId { get; set; }

    // Navigation properties
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
Paso 3.7: Crear entidad IndustryType
1.	Click derecho en Domain/Entities/Catalog → Add → Class
2.	Name: IndustryType.cs
csharp
using Domain.Common;

namespace Domain.Entities.Catalog;

public class IndustryType : AuditableEntity
{
    public int IndustryTypeId { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? BranchId { get; set; }
    public string IndustryCode { get; set; } = null!;
    public string Description { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
Paso 3.8: Crear entidad Company
1.	Click derecho en Domain/Entities/Management → Add → Class
2.	Name: Company.cs
csharp
using Domain.Common;
using Domain.Entities.Catalog;

namespace Domain.Entities.Management;

public class Company : AuditableEntity
{
    public Guid CompanyId { get; set; }
    public string BusinessName { get; set; } = null!;
    
    // Address
    public string? Street { get; set; }
    public string? ExteriorNumber { get; set; }
    public string? InteriorNumber { get; set; }
    public string? Neighborhood { get; set; }
    public string? Locality { get; set; }
    public string? Municipality { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    
    // Fiscal & Contact
    public string? TaxId { get; set; }
    public string? PrimaryPhone { get; set; }
    public string? SecondaryPhone { get; set; }
    
    // System info
    public string? ErpSystemCode { get; set; }
    public int? IndustryTypeId { get; set; }
    public string? CompanyTitle { get; set; }
    public int? LegacyRecordId { get; set; }

    // Navigation properties
    public virtual IndustryType? IndustryType { get; set; }
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
Paso 3.9: Crear entidad Branch
1.	Click derecho en Domain/Entities/Management → Add → Class
2.	Name: Branch.cs
csharp
using Domain.Common;

namespace Domain.Entities.Management;

public class Branch : AuditableEntity
{
    public Guid BranchId { get; set; }
    public Guid CompanyId { get; set; }
    
    // Branch Information
    public string Name { get; set; } = string.Empty;
    public string? CommercialName { get; set; }
    public int? BranchTypeId { get; set; }
    
    // Physical Address
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string AddressSuburb { get; set; } = string.Empty;
    public string AddressCity { get; set; } = string.Empty;
    public string AddressMunicipality { get; set; } = string.Empty;
    public string AddressState { get; set; } = string.Empty;
    public string AddressPostalCode { get; set; } = string.Empty;
    public string AddressCountry { get; set; } = "México";
    
    // Contact Information
    public string TaxIdentificationNumber { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? SecondaryPhoneNumber { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public string? Website { get; set; }

    // Navigation properties
    public virtual Company Company { get; set; } = null!;
}
Paso 3.10: Crear entidad User
1.	Click derecho en Domain/Entities/Security → Add → Class
2.	Name: User.cs
csharp
using Domain.Common;
using Domain.Entities.Catalog;

namespace Domain.Entities.Security;

public class User : AuditableEntity
{
    public int UserId { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? BranchId { get; set; }
    public string UserAccount { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Password { get; set; }
    public bool PrivacyAccepted { get; set; }
    public DateTime? AcceptanceDate { get; set; }
    public bool ChangePasswordRequest { get; set; } = true;
    public int CountryId { get; set; }
    public int RoleId { get; set; }
    public int? PrivacyPolicyId { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? Expiration { get; set; }
    public Guid? PasswordRecoveryToken { get; set; }
    public int? IncorrectPasswordAttempts { get; set; }
    public DateTime? BlockedToDate { get; set; }

    // Navigation properties
    public virtual Country Country { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
}
Paso 3.11: Crear entidad Group
1.	Click derecho en Domain/Entities/Catalog → Add → Class
2.	Name: Group.cs
csharp
using Domain.Common;

namespace Domain.Entities.Catalog;

public class Group : AuditableEntity
{
    public int GroupId { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? BranchId { get; set; }
    public string Name { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<SubGroup> SubGroups { get; set; } = new List<SubGroup>();
}
Paso 3.12: Crear entidad SubGroup
1.	Click derecho en Domain/Entities/Catalog → Add → Class
2.	Name: SubGroup.cs
csharp
using Domain.Common;

namespace Domain.Entities.Catalog;

public class SubGroup : AuditableEntity
{
    public int SubGroupId { get; set; }
    public int GroupId { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? BranchId { get; set; }
    public string Name { get; set; } = null!;

    // Navigation properties
    public virtual Group Group { get; set; } = null!;
}
________________________________________
PARTE 4: SHARED LAYER
Paso 4.1: Crear estructura de carpetas en Shared
1.	Click derecho en Shared → Add → New Folder → Common
2.	Click derecho en Shared → Add → New Folder → DTOs
Paso 4.2: Crear PaginationDto
1.	Click derecho en Shared/DTOs → Add → Class
2.	Name: PaginationDto.cs
csharp
namespace Shared.DTOs;

public class PaginationDto
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
Paso 4.3: Crear PagedResult
1.	Click derecho en Shared/Common → Add → Class
2.	Name: PagedResult.cs
csharp
namespace Shared.Common;

public class PagedResult<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}
Paso 4.4: Crear Metadata
1.	Click derecho en Shared/Common → Add → Class
2.	Name: Metadata.cs
csharp
namespace Shared.Common;

public class Metadata
{
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}
Paso 4.5: Crear ApiResponse
1.	Click derecho en Shared/Common → Add → Class
2.	Name: ApiResponse.cs
csharp
namespace Shared.Common;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public DateTime Timestamp { get; set; }
    public IDictionary<string, string[]>? Errors { get; set; }

    public ApiResponse()
    {
        Timestamp = DateTime.UtcNow;
    }

    public ApiResponse(T data, string? message = null)
    {
        Success = true;
        Data = data;
        Message = message;
        StatusCode = 200;
        Timestamp = DateTime.UtcNow;
    }

    public static ApiResponse<T> SuccessResponse(T data, string? message = null)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data,
            Message = message,
            StatusCode = 200,
            Timestamp = DateTime.UtcNow
        };
    }

    public static ApiResponse<T> ErrorResponse(
        string message,
        int statusCode = 400,
        IDictionary<string, string[]>? errors = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message,
            StatusCode = statusCode,
            Errors = errors,
            Timestamp = DateTime.UtcNow
        };
    }

    public static ApiResponse<T> CreatedResponse(T data, string? message = null)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data,
            Message = message ?? "Registro creado exitosamente",
            StatusCode = 201,
            Timestamp = DateTime.UtcNow
        };
    }

    public static ApiResponse<T> NotFoundResponse(string? message = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message ?? "Recurso no encontrado",
            StatusCode = 404,
            Timestamp = DateTime.UtcNow
        };
    }
}
________________________________________
PARTE 5: APPLICATION LAYER
Paso 5.1: Crear estructura de carpetas en Application
1.	Click derecho en Application → Add → New Folder → Interfaces
2.	Dentro de Interfaces, crear subcarpetas:
•	Repositories
•	Services
3.	Click derecho en Application → Add → New Folder → Services
4.	Click derecho en Application → Add → New Folder → DTOs
5.	Dentro de DTOs, crear subcarpetas:
•	Country
•	Role
•	User
•	Company
•	Branch
•	Group
•	SubGroup
•	IndustryType
6.	Click derecho en Application → Add → New Folder → Mappings
7.	Click derecho en Application → Add → New Folder → Validators
Paso 5.2: Crear IGenericRepository
1.	Click derecho en Application/Interfaces/Repositories → Add → Class
2.	Name: IGenericRepository.cs
csharp
namespace Application.Interfaces.Repositories;

public interface IGenericRepository<T, TKey> where T : class
{
    Task<T?> GetByIdAsync(TKey id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<int> SaveChangesAsync();
}
Paso 5.3: Crear IGenericService
1.	Click derecho en Application/Interfaces/Services → Add → Class
2.	Name: IGenericService.cs
csharp
using Shared.Common;
using Shared.DTOs;

namespace Application.Interfaces.Services;

public interface IGenericService<TEntity, TDto, TKey> where TEntity : class
{
    Task<ApiResponse<PagedResult<TDto>>> GetAllAsync(PaginationDto pagination);
    Task<ApiResponse<TDto>> GetByIdAsync(TKey id);
    Task<ApiResponse<TDto>> CreateAsync<TCreateDto>(TCreateDto createDto, int userId);
    Task<ApiResponse<TDto>> UpdateAsync<TUpdateDto>(TKey id, TUpdateDto updateDto, int userId);
    Task<ApiResponse<string>> DeleteAsync(TKey id);
}
Paso 5.4: Crear ICountryRepository
1.	Click derecho en Application/Interfaces/Repositories → Add → Class
2.	Name: ICountryRepository.cs
csharp
using Domain.Entities.Catalog;

namespace Application.Interfaces.Repositories;

public interface ICountryRepository : IGenericRepository<Country, int>
{
    Task<bool> ExistsByCodeAsync(string code, int? excludeId = null);
    Task<Country?> GetByCodeAsync(string code);
}
Paso 5.5: Crear IRoleRepository
1.	Click derecho en Application/Interfaces/Repositories → Add → Class
2.	Name: IRoleRepository.cs
csharp
using Domain.Entities.Security;

namespace Application.Interfaces.Repositories;

public interface IRoleRepository : IGenericRepository<Role, int>
{
    Task<bool> ExistsByCodeAsync(string code, int? excludeId = null);
    Task<Role?> GetByCodeAsync(string code);
}
Paso 5.6: Crear ICompanyRepository
1.	Click derecho en Application/Interfaces/Repositories → Add → Class
2.	Name: ICompanyRepository.cs
csharp
using Domain.Entities.Management;

namespace Application.Interfaces.Repositories;

public interface ICompanyRepository : IGenericRepository<Company, Guid>
{
    Task<bool> ExistsByBusinessNameAsync(string businessName, Guid? excludeId = null);
    Task<bool> ExistsByTaxIdAsync(string taxId, Guid? excludeId = null);
}
Paso 5.7: Crear IBranchRepository
1.	Click derecho en Application/Interfaces/Repositories → Add → Class
2.	Name: IBranchRepository.cs
csharp
using Domain.Entities.Management;

namespace Application.Interfaces.Repositories;

public interface IBranchRepository : IGenericRepository<Branch, Guid>
{
    Task<IEnumerable<Branch>> GetByCompanyIdAsync(Guid companyId);
}
Paso 5.8: Crear IUserRepository
1.	Click derecho en Application/Interfaces/Repositories → Add → Class
2.	Name: IUserRepository.cs
csharp
using Domain.Entities.Security;

namespace Application.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User, int>
{
    Task<User?> GetByUserAccountAsync(string userAccount);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> ExistsByUserAccountAsync(string userAccount, int? excludeId = null);
    Task<bool> ExistsByEmailAsync(string email, int? excludeId = null);
}
Paso 5.9: Crear DTOs de Country
CountryDto.cs
1.	Click derecho en Application/DTOs/Country → Add → Class
2.	Name: CountryDto.cs
csharp
namespace Application.DTOs.Country;

public class CountryDto
{
    public int CountryId { get; set; }
    public string CountryCode { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? UTCdiff { get; set; }
    public int? LanguageId { get; set; }
    public bool Active { get; set; }
}
CreateCountryDto.cs
csharp
namespace Application.DTOs.Country;

public class CreateCountryDto
{
    public string CountryCode { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? UTCdiff { get; set; }
    public int? LanguageId { get; set; }
}
UpdateCountryDto.cs
csharp
namespace Application.DTOs.Country;

public class UpdateCountryDto
{
    public string CountryCode { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? UTCdiff { get; set; }
    public int? LanguageId { get; set; }
}
Paso 5.10: Crear DTOs de Role
RoleDto.cs
csharp
namespace Application.DTOs.Role;

public class RoleDto
{
    public int RoleId { get; set; }
    public string RoleCode { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Active { get; set; }
}
CreateRoleDto.cs
csharp
namespace Application.DTOs.Role;

public class CreateRoleDto
{
    public string RoleCode { get; set; } = null!;
    public string Description { get; set; } = null!;
}
UpdateRoleDto.cs
csharp
namespace Application.DTOs.Role;

public class UpdateRoleDto
{
    public string RoleCode { get; set; } = null!;
    public string Description { get; set; } = null!;
}
Paso 5.11: Crear DTOs de Company
CompanyDto.cs
csharp
namespace Application.DTOs.Company;

public class CompanyDto
{
    public Guid CompanyId { get; set; }
    public string BusinessName { get; set; } = null!;
    public string? Street { get; set; }
    public string? ExteriorNumber { get; set; }
    public string? InteriorNumber { get; set; }
    public string? Neighborhood { get; set; }
    public string? Locality { get; set; }
    public string? Municipality { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    public string? TaxId { get; set; }
    public string? PrimaryPhone { get; set; }
    public string? SecondaryPhone { get; set; }
    public string? ErpSystemCode { get; set; }
    public int? IndustryTypeId { get; set; }
    public string? CompanyTitle { get; set; }
    public bool Active { get; set; }
}
CreateCompanyDto.cs
csharp
namespace Application.DTOs.Company;

public class CreateCompanyDto
{
    public string BusinessName { get; set; } = null!;
    public string? Street { get; set; }
    public string? ExteriorNumber { get; set; }
    public string? InteriorNumber { get; set; }
    public string? Neighborhood { get; set; }
    public string? Locality { get; set; }
    public string? Municipality { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    public string? TaxId { get; set; }
    public string? PrimaryPhone { get; set; }
    public string? SecondaryPhone { get; set; }
    public string? ErpSystemCode { get; set; }
    public int? IndustryTypeId { get; set; }
    public string? CompanyTitle { get; set; }
}
UpdateCompanyDto.cs
csharp
namespace Application.DTOs.Company;

public class UpdateCompanyDto
{
    public string BusinessName { get; set; } = null!;
    public string? Street { get; set; }
    public string? ExteriorNumber { get; set; }
    public string? InteriorNumber { get; set; }
    public string? Neighborhood { get; set; }
    public string? Locality { get; set; }
    public string? Municipality { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    public string? TaxId { get; set; }
    public string? PrimaryPhone { get; set; }
    public string? SecondaryPhone { get; set; }
    public string? ErpSystemCode { get; set; }
    public int? IndustryTypeId { get; set; }
    public string? CompanyTitle { get; set; }
}
Paso 5.12: Crear DTOs de Branch
BranchDto.cs
csharp
namespace Application.DTOs.Branch;

public class BranchDto
{
    public Guid BranchId { get; set; }
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string? CommercialName { get; set; }
    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; }
    public string AddressSuburb { get; set; } = null!;
    public string AddressCity { get; set; } = null!;
    public string AddressMunicipality { get; set; } = null!;
    public string AddressState { get; set; } = null!;
    public string AddressPostalCode { get; set; } = null!;
    public string AddressCountry { get; set; } = null!;
    public string TaxIdentificationNumber { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? SecondaryPhoneNumber { get; set; }
    public string EmailAddress { get; set; } = null!;
    public string? Website { get; set; }
    public bool Active { get; set; }
}
CreateBranchDto.cs
csharp
namespace Application.DTOs.Branch;

public class CreateBranchDto
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string? CommercialName { get; set; }
    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; }
    public string AddressSuburb { get; set; } = null!;
    public string AddressCity { get; set; } = null!;
    public string AddressMunicipality { get; set; } = null!;
    public string AddressState { get; set; } = null!;
    public string AddressPostalCode { get; set; } = null!;
    public string AddressCountry { get; set; } = "México";
    public string TaxIdentificationNumber { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? SecondaryPhoneNumber { get; set; }
    public string EmailAddress { get; set; } = null!;
    public string? Website { get; set; }
}
UpdateBranchDto.cs
csharp
namespace Application.DTOs.Branch;

public class UpdateBranchDto
{
    public string Name { get; set; } = null!;
    public string? CommercialName { get; set; }
    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; }
    public string AddressSuburb { get; set; } = null!;
    public string AddressCity { get; set; } = null!;
    public string AddressMunicipality { get; set; } = null!;
    public string AddressState { get; set; } = null!;
    public string AddressPostalCode { get; set; } = null!;
    public string AddressCountry { get; set; } = null!;
    public string TaxIdentificationNumber { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? SecondaryPhoneNumber { get; set; }
    public string EmailAddress { get; set; } = null!;
    public string? Website { get; set; }
}
Paso 5.13: Crear AutoMapper Profile
1.	Click derecho en Application/Mappings → Add → Class
2.	Name: MappingProfile.cs
csharp
using Application.DTOs.Branch;
using Application.DTOs.Company;
using Application.DTOs.Country;
using Application.DTOs.Role;
using AutoMapper;
using Domain.Entities.Catalog;
using Domain.Entities.Management;
using Domain.Entities.Security;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Country mappings
        CreateMap<Country, CountryDto>();
        CreateMap<CreateCountryDto, Country>();
        CreateMap<UpdateCountryDto, Country>();

        // Role mappings
        CreateMap<Role, RoleDto>();
        CreateMap<CreateRoleDto, Role>();
        CreateMap<UpdateRoleDto, Role>();

        // Company mappings
        CreateMap<Company, CompanyDto>();
        CreateMap<CreateCompanyDto, Company>();
        CreateMap<UpdateCompanyDto, Company>();

        // Branch mappings
        CreateMap<Branch, BranchDto>();
        CreateMap<CreateBranchDto, Branch>();
        CreateMap<UpdateBranchDto, Branch>();
    }
}
Paso 5.14: Crear GenericService
1.	Click derecho en Application/Services → Add → Class
2.	Name: GenericService.cs
csharp
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Shared.Common;
using Shared.DTOs;

namespace Application.Services;

public class GenericService<TEntity, TDto, TKey> : IGenericService<TEntity, TDto, TKey>
    where TEntity : class
{
    protected readonly IGenericRepository<TEntity, TKey> _repository;
    protected readonly IMapper _mapper;

    public GenericService(IGenericRepository<TEntity, TKey> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<ApiResponse<PagedResult<TDto>>> GetAllAsync(PaginationDto pagination)
    {
        try
        {
            var entities = await _repository.GetAllAsync();
            var totalCount = entities.Count();
            
            var pagedEntities = entities
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToList();

            var dtos = _mapper.Map<List<TDto>>(pagedEntities);

            var pagedResult = new PagedResult<TDto>
            {
                Items = dtos,
                TotalCount = totalCount,
                PageSize = pagination.PageSize,
                CurrentPage = pagination.Page
            };

            return ApiResponse<PagedResult<TDto>>.SuccessResponse(pagedResult);
        }
        catch (Exception ex)
        {
            return ApiResponse<PagedResult<TDto>>.ErrorResponse(
                $"Error al obtener los registros: {ex.Message}",
                500
            );
        }
    }

    public virtual async Task<ApiResponse<TDto>> GetByIdAsync(TKey id)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);
            
            if (entity == null)
            {
                return ApiResponse<TDto>.NotFoundResponse(
                    $"Registro con ID {id} no encontrado"
                );
            }

            var dto = _mapper.Map<TDto>(entity);
            return ApiResponse<TDto>.SuccessResponse(dto);
        }
        catch (Exception ex)
        {
            return ApiResponse<TDto>.ErrorResponse(
                $"Error al obtener el registro: {ex.Message}",
                500
            );
        }
    }

    public virtual async Task<ApiResponse<TDto>> CreateAsync<TCreateDto>(TCreateDto createDto, int userId)
    {
        try
        {
            var entity = _mapper.Map<TEntity>(createDto);
            
            // Set audit fields
            SetAuditFieldsForCreate(entity, userId);
            
            var createdEntity = await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            
            var dto = _mapper.Map<TDto>(createdEntity);
            return ApiResponse<TDto>.CreatedResponse(dto);
        }
        catch (Exception ex)
        {
            return ApiResponse<TDto>.ErrorResponse(
                $"Error al crear el registro: {ex.Message}",
                500
            );
        }
    }

    public virtual async Task<ApiResponse<TDto>> UpdateAsync<TUpdateDto>(TKey id, TUpdateDto updateDto, int userId)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);
            
            if (entity == null)
            {
                return ApiResponse<TDto>.NotFoundResponse(
                    $"Registro con ID {id} no encontrado"
                );
            }

            _mapper.Map(updateDto, entity);
            SetAuditFieldsForUpdate(entity, userId);
            
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            
            var dto = _mapper.Map<TDto>(entity);
            return ApiResponse<TDto>.SuccessResponse(dto, "Registro actualizado exitosamente");
        }
        catch (Exception ex)
        {
            return ApiResponse<TDto>.ErrorResponse(
                $"Error al actualizar el registro: {ex.Message}",
                500
            );
        }
    }

    public virtual async Task<ApiResponse<string>> DeleteAsync(TKey id)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);
            
            if (entity == null)
            {
                return ApiResponse<string>.NotFoundResponse(
                    $"Registro con ID {id} no encontrado"
                );
            }

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
            
            return ApiResponse<string>.SuccessResponse(
                "Eliminado",
                "Registro eliminado exitosamente"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<string>.ErrorResponse(
                $"Error al eliminar el registro: {ex.Message}",
                500
            );
        }
    }

    protected virtual void SetAuditFieldsForCreate(TEntity entity, int userId)
    {
        var type = typeof(TEntity);
        
        var createUserProp = type.GetProperty("CreateUser");
        if (createUserProp != null && createUserProp.CanWrite)
            createUserProp.SetValue(entity, userId);

        var dateCreatedProp = type.GetProperty("DateCreatedTime");
        if (dateCreatedProp != null && dateCreatedProp.CanWrite)
            dateCreatedProp.SetValue(entity, DateTime.UtcNow);

        var dateUpdatedProp = type.GetProperty("DateUpdatedTime");
        if (dateUpdatedProp != null && dateUpdatedProp.CanWrite)
            dateUpdatedProp.SetValue(entity, DateTime.UtcNow);

        var activeProp = type.GetProperty("Active");
        if (activeProp != null && activeProp.CanWrite)
            activeProp.SetValue(entity, true);
    }

    protected virtual void SetAuditFieldsForUpdate(TEntity entity, int userId)
    {
        var type = typeof(TEntity);
        
        var updateUserProp = type.GetProperty("UpdateUser");
        if (updateUserProp != null && updateUserProp.CanWrite)
            updateUserProp.SetValue(entity, userId);

        var dateUpdatedProp = type.GetProperty("DateUpdatedTime");
        if (dateUpdatedProp != null && dateUpdatedProp.CanWrite)
            dateUpdatedProp.SetValue(entity, DateTime.UtcNow);
    }
}
Paso 5.15: Crear CountryService
1.	Click derecho en Application/Services → Add → Class
2.	Name: CountryService.cs
csharp
using Application.DTOs.Country;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Catalog;
using Shared.Common;

namespace Application.Services;

public class CountryService : GenericService<Country, CountryDto, int>
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository repository, IMapper mapper) 
        : base(repository, mapper)
    {
        _countryRepository = repository;
    }

    public override async Task<ApiResponse<CountryDto>> CreateAsync<TCreateDto>(TCreateDto createDto, int userId)
    {
        var dto = createDto as CreateCountryDto;
        if (dto == null)
        {
            return ApiResponse<CountryDto>.ErrorResponse("Datos inválidos", 400);
        }

        // Validar código único
        var exists = await _countryRepository.ExistsByCodeAsync(dto.CountryCode);
        if (exists)
        {
            return ApiResponse<CountryDto>.ErrorResponse(
                "Ya existe un país con ese código",
                400
            );
        }

        return await base.CreateAsync(createDto, userId);
    }

    public override async Task<ApiResponse<CountryDto>> UpdateAsync<TUpdateDto>(int id, TUpdateDto updateDto, int userId)
    {
        var dto = updateDto as UpdateCountryDto;
        if (dto == null)
        {
            return ApiResponse<CountryDto>.ErrorResponse("Datos inválidos", 400);
        }

        // Validar código único
        var exists = await _countryRepository.ExistsByCodeAsync(dto.CountryCode, id);
        if (exists)
        {
            return ApiResponse<CountryDto>.ErrorResponse(
                "Ya existe otro país con ese código",
                400
            );
        }

        return await base.UpdateAsync(id, updateDto, userId);
    }
}
Paso 5.16: Crear CompanyService
1.	Click derecho en Application/Services → Add → Class
2.	Name: CompanyService.cs
csharp
using Application.DTOs.Company;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Management;
using Shared.Common;

namespace Application.Services;

public class CompanyService : GenericService<Company, CompanyDto, Guid>
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository repository, IMapper mapper) 
        : base(repository, mapper)
    {
        _companyRepository = repository;
    }

    public override async Task<ApiResponse<CompanyDto>> CreateAsync<TCreateDto>(TCreateDto createDto, int userId)
    {
        var dto = createDto as CreateCompanyDto;
        if (dto == null)
        {
            return ApiResponse<CompanyDto>.ErrorResponse("Datos inválidos", 400);
        }

        // Validar BusinessName único
        var existsName = await _companyRepository.ExistsByBusinessNameAsync(dto.BusinessName);
        if (existsName)
        {
            return ApiResponse<CompanyDto>.ErrorResponse(
                "Ya existe una empresa con ese nombre comercial",
                400
            );
        }

        // Validar TaxId único si se proporciona
        if (!string.IsNullOrEmpty(dto.TaxId))
        {
            var existsTaxId = await _companyRepository.ExistsByTaxIdAsync(dto.TaxId);
            if (existsTaxId)
            {
                return ApiResponse<CompanyDto>.ErrorResponse(
                    "Ya existe una empresa con ese RFC/Tax ID",
                    400
                );
            }
        }

        return await base.CreateAsync(createDto, userId);
    }

    public override async Task<ApiResponse<CompanyDto>> UpdateAsync<TUpdateDto>(Guid id, TUpdateDto updateDto, int userId)
    {
        var dto = updateDto as UpdateCompanyDto;
        if (dto == null)
        {
            return ApiResponse<CompanyDto>.ErrorResponse("Datos inválidos", 400);
        }

        // Validar BusinessName único
        var existsName = await _companyRepository.ExistsByBusinessNameAsync(dto.BusinessName, id);
        if (existsName)
        {
            return ApiResponse<CompanyDto>.ErrorResponse(
                "Ya existe otra empresa con ese nombre comercial",
                400
            );
        }

        // Validar TaxId único
        if (!string.IsNullOrEmpty(dto.TaxId))
        {
            var existsTaxId = await _companyRepository.ExistsByTaxIdAsync(dto.TaxId, id);
            if (existsTaxId)
            {
                return ApiResponse<CompanyDto>.ErrorResponse(
                    "Ya existe otra empresa con ese RFC/Tax ID",
                    400
                );
            }
        }

        return await base.UpdateAsync(id, updateDto, userId);
    }
}
________________________________________
PARTE 6: INFRASTRUCTURE LAYER
Paso 6.1: Crear estructura de carpetas en Infrastructure
1.	Click derecho en Infrastructure → Add → New Folder → Persistence
2.	Dentro de Persistence, crear:
•	Configurations
3.	Click derecho en Infrastructure → Add → New Folder → Repositories
Paso 6.2: Crear AppDbContext
1.	Click derecho en Infrastructure/Persistence → Add → Class
2.	Name: AppDbContext.cs
csharp
using Domain.Entities.Catalog;
using Domain.Entities.Management;
using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Security Schema
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    // Catalog Schema
    public DbSet<Country> Countries { get; set; }
    public DbSet<IndustryType> IndustryTypes { get; set; }
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
Paso 6.3: Crear UserConfiguration
1.	Click derecho en Infrastructure/Persistence/Configurations → Add → Class
2.	Name: UserConfiguration.cs
csharp
using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", "Security");

        builder.HasKey(u => u.UserId);

        builder.Property(u => u.UserId)
            .HasColumnName("UserId");

        builder.Property(u => u.CompanyId)
            .HasColumnName("CompanyId");

        builder.Property(u => u.BranchId)
            .HasColumnName("BranchId");

        builder.Property(u => u.UserAccount)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("UserAccount")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Email")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Name")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("PhoneNumber")
            .IsUnicode(false);

        builder.Property(u => u.Password)
            .HasMaxLength(250)
            .HasColumnName("Password")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        builder.Property(u => u.PrivacyAccepted)
            .IsRequired()
            .HasColumnName("PrivacyAccepted")
            .HasDefaultValue(false);

        builder.Property(u => u.AcceptanceDate)
            .HasColumnName("AcceptanceDate");

        builder.Property(u => u.ChangePasswordRequest)
            .IsRequired()
            .HasColumnName("ChangePasswordRequest")
            .HasDefaultValue(true);

        builder.Property(u => u.CountryId)
            .IsRequired()
            .HasColumnName("CountryId");

        builder.Property(u => u.RoleId)
            .IsRequired()
            .HasColumnName("RoleId");

        builder.Property(u => u.PrivacyPolicyId)
            .HasColumnName("PrivacyPolicyId");

        builder.Property(u => u.CreatedBy)
            .HasColumnName("CreatedBy");

        builder.Property(u => u.UpdatedBy)
            .HasColumnName("UpdatedBy");

        builder.Property(u => u.RefreshToken)
            .HasMaxLength(255)
            .HasColumnName("RefreshToken")
            .IsUnicode(false);

        builder.Property(u => u.Expiration)
            .HasColumnName("Expiration");

        builder.Property(u => u.PasswordRecoveryToken)
            .HasColumnName("PasswordRecoveryToken");

        builder.Property(u => u.IncorrectPasswordAttempts)
            .HasColumnName("IncorrectPasswordAttempts");

        builder.Property(u => u.BlockedToDate)
            .HasColumnName("BlockedToDate");

        // Audit fields
        builder.Property(u => u.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(u => u.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(u => u.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(u => u.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(u => u.UpdateUser)
            .HasColumnName("UpdateUser");

        // Indexes
        builder.HasIndex(u => u.UserAccount)
            .IsUnique()
            .HasDatabaseName("IX_User_UserAccount");

        // Relationships
        builder.HasOne(u => u.Country)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CountryId)
            .HasConstraintName("FK_User_Country")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .HasConstraintName("FK_User_Role")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
Paso 6.4: Crear RoleConfiguration
csharp
using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role", "Security");

        builder.HasKey(r => r.RoleId);

        builder.Property(r => r.RoleId)
            .HasColumnName("RoleId");

        builder.Property(r => r.CompanyId)
            .HasColumnName("CompanyId");

        builder.Property(r => r.BranchId)
            .HasColumnName("BranchId");

        builder.Property(r => r.RoleCode)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("RoleCode")
            .IsUnicode(false);

        builder.Property(r => r.Description)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Description")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        // Audit fields
        builder.Property(r => r.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(r => r.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(r => r.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(r => r.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(r => r.UpdateUser)
            .HasColumnName("UpdateUser");

        // Indexes
        builder.HasIndex(r => r.RoleCode)
            .IsUnique()
            .HasDatabaseName("IX_RoleCode");
    }
}
Paso 6.5: Crear CountryConfiguration
csharp
using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country", "Catalog");

        builder.HasKey(c => c.CountryId);

        builder.Property(c => c.CountryId)
            .HasColumnName("CountryId");

        builder.Property(c => c.CompanyId)
            .HasColumnName("CompanyId");

        builder.Property(c => c.BranchId)
            .HasColumnName("BranchId");

        builder.Property(c => c.CountryCode)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("CountryCode")
            .IsUnicode(false);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Description")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        builder.Property(c => c.UTCdiff)
            .HasColumnName("UTCdiff");

        builder.Property(c => c.LanguageId)
            .HasColumnName("LanguageId");

        // Audit fields
        builder.Property(c => c.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(c => c.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(c => c.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(c => c.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(c => c.UpdateUser)
            .HasColumnName("UpdateUser");

        // Indexes
        builder.HasIndex(c => c.CountryCode)
            .IsUnique()
            .HasDatabaseName("IX_Country_CountryCode");
    }
}
Paso 6.6: Crear IndustryTypeConfiguration
csharp
using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class IndustryTypeConfiguration : IEntityTypeConfiguration<IndustryType>
{
    public void Configure(EntityTypeBuilder<IndustryType> builder)
    {
        builder.ToTable("IndustryTypes", "Catalog");

        builder.HasKey(i => i.IndustryTypeId);

        builder.Property(i => i.IndustryTypeId)
            .HasColumnName("IndustryTypeId");

        builder.Property(i => i.CompanyId)
            .HasColumnName("CompanyId");

        builder.Property(i => i.BranchId)
            .HasColumnName("BranchId");

        builder.Property(i => i.IndustryCode)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("IndustryCode")
            .IsUnicode(false);

        builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Description")
            .IsUnicode(false);

        // Audit fields
        builder.Property(i => i.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(i => i.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(i => i.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(i => i.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(i => i.UpdateUser)
            .HasColumnName("UpdateUser");
    }
}
Paso 6.7: Crear CompanyConfiguration
csharp
using Domain.Entities.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies", "Management");

        builder.HasKey(c => c.CompanyId);

        builder.Property(c => c.CompanyId)
            .HasColumnName("CompanyId")
            .HasDefaultValueSql("NEWID()");

        builder.Property(c => c.BusinessName)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("BusinessName")
            .IsUnicode(false);

        builder.Property(c => c.Street)
            .HasMaxLength(80)
            .HasColumnName("Street")
            .IsUnicode(false);

        builder.Property(c => c.ExteriorNumber)
            .HasMaxLength(20)
            .HasColumnName("ExteriorNumber")
            .IsUnicode(false);

        builder.Property(c => c.InteriorNumber)
            .HasMaxLength(20)
            .HasColumnName("InteriorNumber")
            .IsUnicode(false);

        builder.Property(c => c.Neighborhood)
            .HasMaxLength(80)
            .HasColumnName("Neighborhood")
            .IsUnicode(false);

        builder.Property(c => c.Locality)
            .HasMaxLength(80)
            .HasColumnName("Locality")
            .IsUnicode(false);

        builder.Property(c => c.Municipality)
            .HasMaxLength(80)
            .HasColumnName("Municipality")
            .IsUnicode(false);

        builder.Property(c => c.State)
            .HasMaxLength(80)
            .HasColumnName("State")
            .IsUnicode(false);

        builder.Property(c => c.ZipCode)
            .HasMaxLength(20)
            .HasColumnName("ZipCode")
            .IsUnicode(false);

        builder.Property(c => c.Country)
            .HasMaxLength(80)
            .HasColumnName("Country")
            .IsUnicode(false);

        builder.Property(c => c.TaxId)
            .HasMaxLength(20)
            .HasColumnName("TaxId")
            .IsUnicode(false);

        builder.Property(c => c.PrimaryPhone)
            .HasMaxLength(15)
            .HasColumnName("PrimaryPhone")
            .IsUnicode(false);

        builder.Property(c => c.SecondaryPhone)
            .HasMaxLength(15)
            .HasColumnName("SecondaryPhone")
            .IsUnicode(false);

        builder.Property(c => c.ErpSystemCode)
            .HasMaxLength(80)
            .HasColumnName("ErpSystemCode")
            .IsUnicode(false);

        builder.Property(c => c.IndustryTypeId)
            .HasColumnName("IndustryTypeId");

        builder.Property(c => c.CompanyTitle)
            .HasMaxLength(280)
            .HasColumnName("CompanyTitle")
            .IsUnicode(false);

        builder.Property(c => c.LegacyRecordId)
            .HasColumnName("LegacyRecordId");

        // Audit fields
        builder.Property(c => c.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(c => c.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(c => c.CreateUser)
            .HasColumnName("CreateUser");

        builder.Property(c => c.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(c => c.UpdateUser)
            .HasColumnName("UpdateUser");

        // Indexes
        builder.HasIndex(c => c.BusinessName)
            .IsUnique()
            .HasDatabaseName("UQ_Companies_BusinessName");

        builder.HasIndex(c => c.TaxId)
            .IsUnique()
            .HasDatabaseName("UQ_Companies_TaxId");

        // Relationships
        builder.HasOne(c => c.IndustryType)
            .WithMany(i => i.Companies)
            .HasForeignKey(c => c.IndustryTypeId)
            .HasConstraintName("FK_Companies_IndustryTypes")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
Paso 6.8: Crear BranchConfiguration
csharp
using Domain.Entities.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches", "Management");

        builder.HasKey(b => b.BranchId);

        builder.Property(b => b.BranchId)
            .HasColumnName("BranchId")
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(b => b.CompanyId)
            .IsRequired()
            .HasColumnName("CompanyId");

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("Name")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.CommercialName)
            .HasMaxLength(80)
            .HasColumnName("CommercialName")
            .IsUnicode(false);

        builder.Property(b => b.BranchTypeId)
            .HasColumnName("BranchTypeId");

        builder.Property(b => b.AddressLine1)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("AddressLine1")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressLine2)
            .HasMaxLength(200)
            .HasColumnName("AddressLine2")
            .IsUnicode(false);

        builder.Property(b => b.AddressSuburb)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("AddressSuburb")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressCity)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("AddressCity")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressMunicipality)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("AddressMunicipality")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressState)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("AddressState")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressPostalCode)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("AddressPostalCode")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.AddressCountry)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("AddressCountry")
            .IsUnicode(false)
            .HasDefaultValue("México");

        builder.Property(b => b.TaxIdentificationNumber)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("TaxIdentificationNumber")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.PhoneNumber)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("PhoneNumber")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.SecondaryPhoneNumber)
            .HasMaxLength(50)
            .HasColumnName("SecondaryPhoneNumber")
            .IsUnicode(false);

        builder.Property(b => b.EmailAddress)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("EmailAddress")
            .IsUnicode(false)
            .HasDefaultValue("");

        builder.Property(b => b.Website)
            .HasMaxLength(100)
            .HasColumnName("Website")
            .IsUnicode(false);

        // Audit fields
        builder.Property(b => b.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(b => b.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(b => b.CreateUser)
            .HasColumnName("CreateUser");

        builder.Property(b => b.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(b => b.UpdateUser)
            .HasColumnName("UpdateUser");

        // Relationships
        builder.HasOne(b => b.Company)
            .WithMany(c => c.Branches)
            .HasForeignKey(b => b.CompanyId)
            .HasConstraintName("FK_Branches_Companies")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
Paso 6.9: Crear GroupConfiguration
csharp
using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups", "dbo");

        builder.HasKey(g => g.GroupId);

        builder.Property(g => g.GroupId)
            .HasColumnName("GroupId");

        builder.Property(g => g.CompanyId)
            .HasColumnName("CompanyId");

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
    }
}
Paso 6.10: Crear SubGroupConfiguration
csharp
using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SubGroupConfiguration : IEntityTypeConfiguration<SubGroup>
{
    public void Configure(EntityTypeBuilder<SubGroup> builder)
    {
        builder.ToTable("SubGroups", "dbo");

        builder.HasKey(s => s.SubGroupId);

        builder.Property(s => s.SubGroupId)
            .HasColumnName("SubGroupId");

        builder.Property(s => s.GroupId)
            .IsRequired()
            .HasColumnName("GroupId");

        builder.Property(s => s.CompanyId)
            .HasColumnName("CompanyId");

        builder.Property(s => s.BranchId)
            .HasColumnName("BranchId");

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Name")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        // Audit fields
        builder.Property(s => s.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasDefaultValue(true);

        builder.Property(s => s.DateCreatedTime)
            .IsRequired()
            .HasColumnName("DateCreatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(s => s.CreateUser)
            .IsRequired()
            .HasColumnName("CreateUser");

        builder.Property(s => s.DateUpdatedTime)
            .IsRequired()
            .HasColumnName("DateUpdatedTime")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(s => s.UpdateUser)
            .HasColumnName("UpdateUser");

        // Relationships
        builder.HasOne(s => s.Group)
            .WithMany(g => g.SubGroups)
            .HasForeignKey(s => s.GroupId)
            .HasConstraintName("FK_SubGroups_Groups_GroupId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
Paso 6.11: Crear GenericRepository
1.	Click derecho en Infrastructure/Repositories → Add → Class
2.	Name: GenericRepository.cs
csharp
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(TKey id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await Task.CompletedTask;
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await Task.CompletedTask;
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
Paso 6.12: Crear CountryRepository
csharp
using Application.Interfaces.Repositories;
using Domain.Entities.Catalog;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CountryRepository : GenericRepository<Country, int>, ICountryRepository
{
    public CountryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByCodeAsync(string code, int? excludeId = null)
    {
        return await _dbSet
            .Where(c => c.CountryCode == code && (excludeId == null || c.CountryId != excludeId))
            .AnyAsync();
    }

    public async Task<Country?> GetByCodeAsync(string code)
    {
        return await _dbSet
            .FirstOrDefaultAsync(c => c.CountryCode == code);
    }
}
Paso 6.13: Crear RoleRepository
csharp
using Application.Interfaces.Repositories;
using Domain.Entities.Security;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoleRepository : GenericRepository<Role, int>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByCodeAsync(string code, int? excludeId = null)
    {
        return await _dbSet
            .Where(r => r.RoleCode == code && (excludeId == null || r.RoleId != excludeId))
            .AnyAsync();
    }

    public async Task<Role?> GetByCodeAsync(string code)
    {
        return await _dbSet
            .FirstOrDefaultAsync(r => r.RoleCode == code);
    }
}
Paso 6.14: Crear CompanyRepository
csharp
using Application.Interfaces.Repositories;
using Domain.Entities.Management;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CompanyRepository : GenericRepository<Company, Guid>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByBusinessNameAsync(string businessName, Guid? excludeId = null)
    {
        return await _dbSet
            .Where(c => c.BusinessName == businessName && (excludeId == null || c.CompanyId != excludeId))
            .AnyAsync();
    }

    public async Task<bool> ExistsByTaxIdAsync(string taxId, Guid? excludeId = null)
    {
        return await _dbSet
            .Where(c => c.TaxId == taxId && (excludeId == null || c.CompanyId != excludeId))
            .AnyAsync();
    }
}
Paso 6.15: Crear BranchRepository
csharp
using Application.Interfaces.Repositories;
using Domain.Entities.Management;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BranchRepository : GenericRepository<Branch, Guid>, IBranchRepository
{
    public BranchRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Branch>> GetByCompanyIdAsync(Guid companyId)
    {
        return await _dbSet
            .Where(b => b.CompanyId == companyId)
            .ToListAsync();
    }
}
Paso 6.16: Crear UserRepository
csharp
using Application.Interfaces.Repositories;
using Domain.Entities.Security;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : GenericRepository<User, int>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUserAccountAsync(string userAccount)
    {
        return await _dbSet
            .Include(u => u.Role)
            .Include(u => u.Country)
            .FirstOrDefaultAsync(u => u.UserAccount == userAccount);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet
            .Include(u => u.Role)
            .Include(u => u.Country)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> ExistsByUserAccountAsync(string userAccount, int? excludeId = null)
    {
        return await _dbSet
            .Where(u => u.UserAccount == userAccount && (excludeId == null || u.UserId != excludeId))
            .AnyAsync();
    }

    public async Task<bool> ExistsByEmailAsync(string email, int? excludeId = null)
    {
        return await _dbSet
            .Where(u => u.Email == email && (excludeId == null || u.UserId != excludeId))
            .AnyAsync();
    }
}
________________________________________
PARTE 7: API LAYER
Paso 7.1: Crear estructura de carpetas en API
1.	Click derecho en API → Add → New Folder → Controllers
2.	Click derecho en API → Add → New Folder → Middleware
3.	Click derecho en API → Add → New Folder → Services
Paso 7.2: Crear JwtSettings
1.	Click derecho en API → Add → Class
2.	Name: JwtSettings.cs
csharp
namespace API;

public class JwtSettings
{
    public string SecretKey { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int ExpirationMinutes { get; set; }
}
Paso 7.3: Crear ITokenService
1.	Click derecho en API/Services → Add → Class
2.	Name: ITokenService.cs
csharp
using Domain.Entities.Security;

namespace API.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
Paso 7.4: Crear TokenService
csharp
using Domain.Entities.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services;

public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;

    public TokenService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.UserAccount),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.RoleCode),
            new Claim("userId", user.UserId.ToString())
        };

        if (user.CompanyId.HasValue)
        {
            claims.Add(new Claim("companyId", user.CompanyId.Value.ToString()));
        }

        if (user.BranchId.HasValue)
        {
            claims.Add(new Claim("branchId", user.BranchId.Value.ToString()));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
Paso 7.5: Crear ExceptionMiddleware
1.	Click derecho en API/Middleware → Add → Class
2.	Name: ExceptionMiddleware.cs
csharp
using Shared.Common;
using System.Net;
using System.Text.Json;

namespace API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = ApiResponse<object>.ErrorResponse(
            "Ocurrió un error interno en el servidor",
            context.Response.StatusCode
        );

        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
    }
}
Paso 7.6: Crear GenericController
1.	Click derecho en API/Controllers → Add → Class
2.	Name: GenericController.cs
csharp
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Common;
using Shared.DTOs;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class GenericController<TEntity, TDto, TCreateDto, TUpdateDto, TKey> : ControllerBase
    where TEntity : class
{
    protected readonly IGenericService<TEntity, TDto, TKey> _service;

    protected GenericController(IGenericService<TEntity, TDto, TKey> service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public virtual async Task<ActionResult<ApiResponse<PagedResult<TDto>>>> GetAll([FromQuery] PaginationDto pagination)
    {
        var response = await _service.GetAllAsync(pagination);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<ApiResponse<TDto>>> GetById(TKey id)
    {
        var response = await _service.GetByIdAsync(id);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<ApiResponse<TDto>>> Create([FromBody] TCreateDto createDto)
    {
        var userId = GetCurrentUserId();
        var response = await _service.CreateAsync(createDto, userId);
        
        if (response.StatusCode == 201)
        {
            return CreatedAtAction(nameof(GetById), new { id = GetEntityId(response.Data!) }, response);
        }
        
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<ApiResponse<TDto>>> Update(TKey id, [FromBody] TUpdateDto updateDto)
    {
        var userId = GetCurrentUserId();
        var response = await _service.UpdateAsync(id, updateDto, userId);
        return StatusCode(response.StatusCode, response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<ApiResponse<string>>> Delete(TKey id)
    {
        var response = await _service.DeleteAsync(id);
        return StatusCode(response.StatusCode, response);
    }

    protected virtual int GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst("userId") ?? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
        return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
    }

    protected abstract object GetEntityId(TDto dto);
}
Paso 7.7: Crear CountriesController
csharp
using Application.DTOs.Country;
using Application.Interfaces.Services;
using Domain.Entities.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "ADMIN,MANAGER")]
public class CountriesController : GenericController<Country, CountryDto, CreateCountryDto, UpdateCountryDto, int>
{
    public CountriesController(IGenericService<Country, CountryDto, int> service) : base(service)
    {
    }

    protected override object GetEntityId(CountryDto dto)
    {
        return dto.CountryId;
    }
}
Paso 7.8: Crear CompaniesController
csharp
using Application.DTOs.Company;
using Application.Interfaces.Services;
using Domain.Entities.Management;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "ADMIN")]
public class CompaniesController : GenericController<Company, CompanyDto, CreateCompanyDto, UpdateCompanyDto, Guid>
{
    public CompaniesController(IGenericService<Company, CompanyDto, Guid> service) : base(service)
    {
    }

    protected override object GetEntityId(CompanyDto dto)
    {
        return dto.CompanyId;
    }
}
Paso 7.9: Crear BranchesController
csharp
using Application.DTOs.Branch;
using Application.Interfaces.Services;
using Domain.Entities.Management;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "ADMIN")]
public class BranchesController : GenericController<Branch, BranchDto, CreateBranchDto, UpdateBranchDto, Guid>
{
    public BranchesController(IGenericService<Branch, BranchDto, Guid> service) : base(service)
    {
    }
    protected override object GetEntityId(BranchDto dto) 
    { 
        return dto.BranchId; 
    }
}

## Paso 7.10: Crear AuthController
```csharp
using API.Services;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Common;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthController(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<LoginResponse>>> Login([FromBody] LoginRequest request)
    {
        var user = await _userRepository.GetByUserAccountAsync(request.UserAccount);

        if (user == null)
        {
            return Unauthorized(ApiResponse<LoginResponse>.ErrorResponse(
                "Usuario o contraseña incorrectos",
                401
            ));
        }

        // Verificar password (en producción usa BCrypt o similar)
        var hashedPassword = HashPassword(request.Password);
        if (user.Password != hashedPassword)
        {
            return Unauthorized(ApiResponse<LoginResponse>.ErrorResponse(
                "Usuario o contraseña incorrectos",
                401
            ));
        }

        var token = _tokenService.GenerateToken(user);

        var response = new LoginResponse
        {
            Token = token,
            UserId = user.UserId,
            UserAccount = user.UserAccount,
            Email = user.Email,
            Name = user.Name,
            Role = user.Role.RoleCode
        };

        return Ok(ApiResponse<LoginResponse>.SuccessResponse(response, "Login exitoso"));
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}

public class LoginRequest
{
    public string UserAccount { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class LoginResponse
{
    public string Token { get; set; } = null!;
    public int UserId { get; set; }
    public string UserAccount { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Role { get; set; } = null!;
}
```

## Paso 7.11: Configurar Program.cs
```csharp
using API;
using API.Middleware;
using API.Services;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Mappings;
using Application.Services;
using Domain.Entities.Catalog;
using Domain.Entities.Management;
using Domain.Entities.Security;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Enterprise API",
        Version = "v1",
        Description = "API con Arquitectura Onion + DDD + EF Core"
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
        b => b.MigrationsAssembly("Infrastructure")
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

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Repositories
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Services
builder.Services.AddScoped<IGenericService<Country, Application.DTOs.Country.CountryDto, int>, CountryService>();
builder.Services.AddScoped<IGenericService<Company, Application.DTOs.Company.CompanyDto, Guid>, CompanyService>();
builder.Services.AddScoped<IGenericService<Branch, Application.DTOs.Branch.BranchDto, Guid>, GenericService<Branch, Application.DTOs.Branch.BranchDto, Guid>>();

// Token service
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
```

## Paso 7.12: Configurar appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EnterpriseDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  },
  "JwtSettings": {
    "SecretKey": "TuClaveSecretaSuperSeguraYLargaDe256Bits!",
    "Issuer": "EnterpriseAPI",
    "Audience": "EnterpriseClient",
    "ExpirationMinutes": 60
  }
}
```

---

# PARTE 8: MIGRACIONES Y BASE DE DATOS

## Paso 8.1: Crear la primera migración

1. En Visual Studio, ve a **Tools** → **NuGet Package Manager** → **Package Manager Console**
2. Asegúrate que el proyecto por defecto sea **Infrastructure**
3. Ejecuta:
```powershell
Add-Migration InitialCreate -Project Infrastructure -StartupProject API
```

## Paso 8.2: Aplicar la migración
```powershell
Update-Database -Project Infrastructure -StartupProject API
```

## Paso 8.3: Verificar la base de datos

1. Abre **SQL Server Object Explorer** en Visual Studio
2. Navega a tu servidor local
3. Verifica que la base de datos `EnterpriseDB` se haya creado
4. Verifica que los esquemas y tablas estén creados

---

# PARTE 9: SEED DATA INICIAL

## Paso 9.1: Crear DbSeeder

1. Click derecho en **Infrastructure/Persistence** → **Add** → **Class**
2. Name: `DbSeeder.cs`
```csharp
using Domain.Entities.Catalog;
using Domain.Entities.Security;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Persistence;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // Seed Roles
        if (!context.Roles.Any())
        {
            var roles = new List<Role>
            {
                new Role
                {
                    RoleCode = "ADMIN",
                    Description = "Administrator",
                    Active = true,
                    DateCreatedTime = DateTime.UtcNow,
                    CreateUser = 1,
                    DateUpdatedTime = DateTime.UtcNow
                },
                new Role
                {
                    RoleCode = "MANAGER",
                    Description = "Manager",
                    Active = true,
                    DateCreatedTime = DateTime.UtcNow,
                    CreateUser = 1,
                    DateUpdatedTime = DateTime.UtcNow
                },
                new Role
                {
                    RoleCode = "USER",
                    Description = "Regular User",
                    Active = true,
                    DateCreatedTime = DateTime.UtcNow,
                    CreateUser = 1,
                    DateUpdatedTime = DateTime.UtcNow
                }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }

        // Seed Countries
        if (!context.Countries.Any())
        {
            var countries = new List<Country>
            {
                new Country
                {
                    CountryCode = "MX",
                    Description = "México",
                    UTCdiff = -6,
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
                    Active = true,
                    DateCreatedTime = DateTime.UtcNow,
                    CreateUser = 1,
                    DateUpdatedTime = DateTime.UtcNow
                }
            };

            await context.Countries.AddRangeAsync(countries);
            await context.SaveChangesAsync();
        }

        // Seed Admin User
        if (!context.Users.Any())
        {
            var adminRole = context.Roles.First(r => r.RoleCode == "ADMIN");
            var country = context.Countries.First(c => c.CountryCode == "MX");

            var adminUser = new User
            {
                UserAccount = "admin",
                Email = "admin@empresa.com",
                Name = "Administrator",
                PhoneNumber = "5551234567",
                Password = HashPassword("Admin123!"),
                PrivacyAccepted = true,
                AcceptanceDate = DateTime.UtcNow,
                ChangePasswordRequest = false,
                CountryId = country.CountryId,
                RoleId = adminRole.RoleId,
                Active = true,
                DateCreatedTime = DateTime.UtcNow,
                CreateUser = 1,
                DateUpdatedTime = DateTime.UtcNow
            };

            await context.Users.AddAsync(adminUser);
            await context.SaveChangesAsync();
        }
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}
```

## Paso 9.2: Ejecutar el Seeder en Program.cs

Agrega esto al final de `Program.cs`, justo antes de `app.Run()`:
```csharp
// Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await DbSeeder.SeedAsync(context);
}

app.Run();
```

---

# PARTE 10: TESTING Y EJECUCIÓN

## Paso 10.1: Compilar la solución

1. Click derecho en la **Solution** → **Build Solution**
2. Verifica que no haya errores

## Paso 10.2: Ejecutar la aplicación

1. Establece **API** como startup project (click derecho → Set as Startup Project)
2. Presiona **F5** o click en el botón **Start**
3. Se abrirá Swagger UI en tu navegador

## Paso 10.3: Probar el login

1. En Swagger, expande **POST /api/Auth/login**
2. Click en **Try it out**
3. Ingresa:
```json
{
  "userAccount": "admin",
  "password": "Admin123!"
}
```
4. Click en **Execute**
5. Copia el token JWT del response

## Paso 10.4: Autorizar en Swagger

1. Click en el botón **Authorize** (candado verde)
2. Pega: `Bearer [tu-token-aquí]`
3. Click **Authorize**
4. Click **Close**

## Paso 10.5: Probar los endpoints

1. Prueba **GET /api/Countries** (debería devolver los países seed)
2. Prueba **POST /api/Companies** (requiere role ADMIN)
3. Prueba **GET /api/Companies**

---

# 🎉 CONCLUSIÓN

Has creado exitosamente una solución completa con:

✅ **Arquitectura Onion** con separación clara de capas
✅ **DDD** con entidades de dominio bien definidas
✅ **EF Core** con configuraciones Fluent API
✅ **JWT Authentication** con roles
✅ **AutoMapper** para mapeo de DTOs
✅ **Middleware** para manejo de errores
✅ **Repository Pattern** genérico y específico
✅ **Service Layer** con validaciones de negocio
✅ **Controllers genéricos** reutilizables
✅ **Swagger** con autenticación JWT
✅ **Seed data** inicial
✅ **Auditoría** automática en todas las entidades
✅ **Schemas** de SQL Server (Security, Catalog, Management)

**Credenciales iniciales:**
- Usuario: `admin`
- Password: `Admin123!`

¿Necesitas alguna aclaración o ajuste adicional?

