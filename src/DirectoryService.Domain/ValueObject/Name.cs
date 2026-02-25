using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObject;

public record Name
{
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 150;
    public string Value { get; }
    
    private Name(string value)
    {
        Value = value;
    }
    
    public static Result<Name, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return GeneralErrors.ValueIsInvalid($"{typeof(Name).FullName}", "Пустая строка", $"{nameof(Department)}");
        
        return new Name(value);
    }
}