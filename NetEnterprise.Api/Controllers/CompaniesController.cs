using Microsoft.AspNetCore.Authorization;
using NetEnterprise.Application.DTOs.Company;
using NetEnterprise.Application.Interfaces.Services;
using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Api.Controllers;

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