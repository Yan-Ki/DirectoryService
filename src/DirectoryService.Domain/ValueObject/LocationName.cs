using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObject;

public record LocationName
{
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 120;
    public string Value { get; }
    
    private LocationName(string value)
    {
        Value = value;
    }
    
    public static Result<LocationName, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return GeneralErrors.ValueIsInvalid($"{typeof(LocationName).FullName}", "Пустая строка", $"{nameof(LocationName)}");
        if (value.Length > MAX_LENGTH) return GeneralErrors.ValueIsInvalid($"{typeof(LocationName).FullName}", $"Длина строки больше {MAX_LENGTH}", $"{nameof(LocationName)}");
        if (value.Length < MIN_LENGTH) return GeneralErrors.ValueIsInvalid($"{typeof(LocationName).FullName}", $"Длина строки меньше {MIN_LENGTH}", $"{nameof(LocationName)}");
        return new LocationName(value);
    }
}