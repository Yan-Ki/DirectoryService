using DirectoryService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("locations")]
public class LocationController:ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateLocationDto location,
        CancellationToken cancellationToken)
    {
        return Ok("Create");
    }

    [HttpGet("{locationId:guid}")]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid locationId,
        CancellationToken cancellationToken)
    {
        return NotFound("GetById");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok("GetAll");
    }

    [HttpPut("{locationId:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid locationId,
        [FromBody] UpdateLocationDto location,
        CancellationToken cancellationToken)
    {
        return Ok("Update");
    }

    [HttpDelete("{locationId:guid}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid locationId,
        CancellationToken cancellationToken)
    {
        return Ok("Delete");
    }
}