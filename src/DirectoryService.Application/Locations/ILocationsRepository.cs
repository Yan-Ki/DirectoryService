using DirectoryService.Domain;

namespace DirectoryService.Application.Locations;

public interface ILocationsRepository
{
    Task<Guid> CreateAsync(Location location, CancellationToken cancellationToken);
    Task<Guid> UpdateAsync(Guid locationId, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(Guid locationId, CancellationToken cancellationToken);
    Task<Location> GetByIdAsync(Guid locationId, CancellationToken cancellationToken);
    Task<List<Location>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> SearchLocationNameAsync(string name, CancellationToken cancellationToken);
}