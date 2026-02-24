using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObject;

public record Description
{
    public const int MAX_LENGTH = 10000;
    public string Value { get; }
    
    private Description(string value)
    {
        Value = value;
    }
    
    public static Result<Description, Error> Create(string value)
    { 
        if (value.Length <= MAX_LENGTH) return GeneralErrors.ValueIsInvalid($"{typeof(Description).FullName}", $"Длина строки больше {MAX_LENGTH}", $"{nameof(Department)}");
        return new Description(value);
    }
}