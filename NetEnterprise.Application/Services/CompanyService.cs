using AutoMapper;
using NetEnterprise.Application.DTOs.Company;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Domain.Entities.Management;
using NetEnterprise.Shared.Common;

namespace NetEnterprise.Application.Services;

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