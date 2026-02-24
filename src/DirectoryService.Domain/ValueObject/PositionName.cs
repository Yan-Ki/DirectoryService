using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObject;

public record PositionName
{
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 100;
    public string Value { get; }
    
    private PositionName(string value)
    {
        Value = value;
    }
    
    public static Result<PositionName, Error> Create(string value)
    {
        var errorMessages = new List<ErrorMessage>();
        if (string.IsNullOrWhiteSpace(value)) return GeneralErrors.ValueIsInvalid($"{typeof(PositionName).FullName}", "Пустая строка", $"{nameof(Department)}");
        if (value.Length > MAX_LENGTH) return GeneralErrors.ValueIsInvalid($"{typeof(PositionName).FullName}", $"Длина строки больше {MAX_LENGTH}", $"{nameof(Department)}");
        if (value.Length < MIN_LENGTH) return GeneralErrors.ValueIsInvalid($"{typeof(PositionName).FullName}", $"Длина строки меньше {MIN_LENGTH}", $"{nameof(Department)}");
        return new PositionName(value);
    }
}