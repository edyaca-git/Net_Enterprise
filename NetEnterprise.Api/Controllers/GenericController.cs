using Microsoft.AspNetCore.Mvc;
using NetEnterprise.Application.Interfaces.Services;
using NetEnterprise.Shared.Common;
using NetEnterprise.Shared.DTOs;

namespace NetEnterprise.Api.Controllers;

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