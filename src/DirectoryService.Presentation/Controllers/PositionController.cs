using DirectoryService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("positions")]
public class PositionController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreatePositionDto position,
        CancellationToken cancellationToken)
    {
        return Ok("Create");
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid positionId, 
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
        [FromRoute] Guid positionId,
        [FromBody] UpdatePositionDto department,
        CancellationToken cancellationToken)
    {
        return Ok("Update");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid positionId,
        CancellationToken cancellationToken)
    {
        return Ok("Delete");
    }
}