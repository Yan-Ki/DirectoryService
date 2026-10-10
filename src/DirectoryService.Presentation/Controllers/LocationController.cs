using DirectoryService.Application.Locations;
using DirectoryService.Contracts;
using DirectoryService.Contracts.Location;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("locations")]
public class LocationController:ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateLocationDto location,
        CancellationToken cancellationToken)
    {
        Guid locationId = await _locationService.Create(location, cancellationToken);
        return Ok(locationId);
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