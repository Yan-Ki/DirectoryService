namespace DirectoryService.Domain.Shared;

public static class GeneralErrors
{
    public static Error ValueIsInvalid(string code, string message, string invalidField)
    {
        return Error.Validation(new ErrorMessage(code, message, invalidField));
    }
}