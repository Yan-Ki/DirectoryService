using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObject;

public partial record Slug
{
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 150;
    
    public string Value { get; }

    private Slug(string value)
    {
        Value = value;
    }
    
    public static Result<Slug, Error> Create(string value)
    {
        string normalized = value.Trim().ToUpperInvariant();
        if (normalized.Length < MIN_LENGTH || normalized.Length > MAX_LENGTH)
            { 
                return GeneralErrors.ValueIsInvalid(
               $"{typeof(Slug).FullName}",
               $"slug (от {MIN_LENGTH} до {MAX_LENGTH})",
               $"{nameof(Slug)}");
            }

        if (!SlugPattern().IsMatch(normalized))
        {
            return GeneralErrors.ValueIsInvalid(
                $"{typeof(Slug).FullName}",
                $"slug только заглавные латинские буквы, цифры и дефисы и не начинается и не заканчивается дефисом",
                $"{nameof(Slug)}");
        }
        
        return new Slug(value);
    }

    [GeneratedRegex(@"^[A-Z0-9](?:[A-Z0-9-]*[A-Z0-9])?$")]
    private static partial Regex SlugPattern();
}
