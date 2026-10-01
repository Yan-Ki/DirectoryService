using DirectoryService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("departments")]
public class DepartmentController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateDepartmentDto department,
        CancellationToken cancellationToken)
    {
        return Ok("Create");
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid departmentId, 
        CancellationToken cancellationToken)
    {
        return NotFound("GetById");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok("GetAll");
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid departmentId,
        [FromBody] UpdateDepartmentDto department,
        CancellationToken cancellationToken)
    {
        return Ok("Update");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid departmentId,
        CancellationToken cancellationToken)
    {
        return Ok("Delete");
    }
}