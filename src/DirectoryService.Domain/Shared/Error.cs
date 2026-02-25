using System.Data.SqlTypes;
using System.Runtime.InteropServices.ObjectiveC;

namespace DirectoryService.Domain.Shared;

public record Error
{
    public IReadOnlyList<ErrorMessage> Messages { get; } = [];
    public ErrorType Type { get; }
    private Error(IEnumerable<ErrorMessage> messages, ErrorType type)
    {
        Messages = messages.ToArray();
        Type = type;
    }
    
    public static Error Validation(params IEnumerable<ErrorMessage> messages) =>
        new (messages, ErrorType.VALIDATION );
}