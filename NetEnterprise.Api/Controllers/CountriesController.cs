using Microsoft.AspNetCore.Authorization;
using NetEnterprise.Application.DTOs.Country;
using NetEnterprise.Application.Interfaces.Services;
using NetEnterprise.Domain.Entities.Global;

namespace NetEnterprise.Api.Controllers;

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