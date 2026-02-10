using AutoMapper;
using NetEnterprise.Application.DTOs.Branch;
using NetEnterprise.Application.DTOs.Company;
using NetEnterprise.Application.DTOs.Country;
using NetEnterprise.Application.DTOs.Role;
using NetEnterprise.Domain.Entities.Global;
using NetEnterprise.Domain.Entities.Management;
using NetEnterprise.Domain.Entities.Security;

namespace NetEnterprise.Application.Mappings;

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