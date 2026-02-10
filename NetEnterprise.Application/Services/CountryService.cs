using AutoMapper;
using NetEnterprise.Application.DTOs.Country;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Domain.Entities.Global;
using NetEnterprise.Shared.Common;

namespace NetEnterprise.Application.Services;

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