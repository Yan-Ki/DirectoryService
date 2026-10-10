using DirectoryService.Contracts;
using DirectoryService.Contracts.Location;
using DirectoryService.Domain;
using DirectoryService.Domain.ValueObject;
using FluentValidation;
using FluentValidation.Results;

namespace DirectoryService.Application.Locations;

public class LocationsService : ILocationService
{
    private readonly ILocationsRepository _locationsRepository;
    private readonly IValidator<CreateLocationDto> _validator;

    public LocationsService(
        ILocationsRepository locationsRepository,
        IValidator<CreateLocationDto> validator)
    {
        _locationsRepository = locationsRepository;
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
        bool locationNameAvailable = await _locationsRepository.SearchLocationNameAsync(locationDto.Name, cancellationToken);
        if (locationNameAvailable)
        {
            throw new ValidationException("Локация уже существует");
        }
        
        // создание сущности Location
        var name = LocationName.CreateLocation(locationDto.Name);
        string adress = $"{locationDto.City},{locationDto.Street},{locationDto.House},{locationDto.Apartment}";
        string timeZone = "Europe/Moscow";
        var location = new Location(null, name, adress, timeZone);
        
        await _locationsRepository.CreateAsync(location, cancellationToken);
        return location.Id;
    }
}