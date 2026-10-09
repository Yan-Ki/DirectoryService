using DirectoryService.Contracts;
using DirectoryService.Contracts.Location;
using DirectoryService.Domain;
using DirectoryService.Domain.ValueObject;
using FluentValidation;
using FluentValidation.Results;

namespace DirectoryService.Application.Locations;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IValidator<CreateLocationDto> _validator;

    public LocationService(
        ILocationRepository locationRepository,
        IValidator<CreateLocationDto> validator)
    {
        _locationRepository = locationRepository;
        _validator = validator;
    }
    
    public async Task<Guid> Create(
        CreateLocationDto locationDto,
        CancellationToken cancellationToken)
    {
        // проверка валидности входных данных
        var validationResult = await _validator.ValidateAsync(locationDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        // проверка на существование локации
        bool locationNameAvailable = await _locationRepository.SearchLocationNameAsync(locationDto.Name, cancellationToken);
        if (locationNameAvailable)
        {
            throw new ValidationException("Локация уже существует");
        }
        
        // создание сущности Location
        var name = LocationName.CreateLocation(locationDto.Name);
        string adress = $"{locationDto.City},{locationDto.Street},{locationDto.House},{locationDto.Apartment}";
        string timeZone = "Europe/Moscow";
        var location = new Location(null, name, adress, timeZone);
        
        await _locationRepository.CreateAsync(location, cancellationToken);
        return location.Id;
    }
}