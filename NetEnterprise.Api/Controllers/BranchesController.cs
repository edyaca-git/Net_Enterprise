using Microsoft.AspNetCore.Authorization;
using NetEnterprise.Application.DTOs.Branch;
using NetEnterprise.Application.Interfaces.Services;
using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Api.Controllers;

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