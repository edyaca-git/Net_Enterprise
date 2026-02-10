using AutoMapper;
using NetEnterprise.Application.Interfaces.Repositories;
using NetEnterprise.Application.Interfaces.Services;
using NetEnterprise.Shared.Common;
using NetEnterprise.Shared.DTOs;

namespace NetEnterprise.Application.Services;

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