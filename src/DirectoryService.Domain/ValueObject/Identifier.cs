using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObject;

public record Identifier
{
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 150;
    public string Value { get; }
    
    private Identifier(string value)
    {
        Value = value;
    }
    
    public static Result<Identifier, Error> Create(string value)
    {
        var errorMessages = new List<ErrorMessage>();
        
        if (string.IsNullOrWhiteSpace(value)) errorMessages.Add(new ErrorMessage($"{nameof(Identifier)}", "Пустая строка", $"{nameof(Department)}"));
        
        if (value.Length > MAX_LENGTH) errorMessages.Add(new ErrorMessage($"{nameof(Identifier)}", $"Длина строки больше {MAX_LENGTH}", $"{nameof(Department)}"));
        
        if (value.Length < MIN_LENGTH) errorMessages.Add(new ErrorMessage($"{nameof(Identifier)}", $"Длина строки меньше {MIN_LENGTH}", $"{nameof(Department)}"));
        
        if (!Regex.IsMatch(value, @"^[a-zA-Z\-]+$")) errorMessages.Add(new ErrorMessage($"{nameof(Identifier)}",
            $"Строка должна содержать только латинские символы", $"{nameof(Department)}"));
        
        return errorMessages.Count>0 ? Error.Validation(errorMessages) : new Identifier(value);
    }
}