using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObject;

public record Path
{
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 150;
    public string Value { get; }
    
    private Path(string value)
    {
        Value = value;
    }
    
    public static Result<Path, Error> Create(string value)
    {
        var errorMessages = new List<ErrorMessage>();
        
        if (string.IsNullOrWhiteSpace(value)) return GeneralErrors.ValueIsInvalid($"{typeof(Path).FullName}", "Пустая строка", $"{nameof(Department)}");
        
        if (value.Length > MAX_LENGTH) return GeneralErrors.ValueIsInvalid($"{typeof(Path).FullName}", $"Длина строки больше {MAX_LENGTH}", $"{nameof(Department)}");
        
        if (value.Length < MIN_LENGTH) return GeneralErrors.ValueIsInvalid($"{typeof(Path).FullName}", $"Длина строки меньше {MIN_LENGTH}", $"{nameof(Department)}");
        
        return new Path(value);
    }
}