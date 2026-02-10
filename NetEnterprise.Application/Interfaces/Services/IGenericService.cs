using NetEnterprise.Shared.Common;
using NetEnterprise.Shared.DTOs;

namespace NetEnterprise.Application.Interfaces.Services;

public interface IGenericService<TEntity, TDto, TKey> where TEntity : class
{
    Task<ApiResponse<PagedResult<TDto>>> GetAllAsync(PaginationDto pagination);

    Task<ApiResponse<TDto>> GetByIdAsync(TKey id);

    Task<ApiResponse<TDto>> CreateAsync<TCreateDto>(TCreateDto createDto, int userId);

    Task<ApiResponse<TDto>> UpdateAsync<TUpdateDto>(TKey id, TUpdateDto updateDto, int userId);

    Task<ApiResponse<string>> DeleteAsync(TKey id);
}