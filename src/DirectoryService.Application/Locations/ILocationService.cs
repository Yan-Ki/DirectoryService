using DirectoryService.Contracts.Location;

namespace DirectoryService.Application.Locations;

public interface ILocationService
{
    Task<Guid> Create(
        CreateLocationDto locationDto,
        CancellationToken cancellationToken);
}