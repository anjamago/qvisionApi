using FluentValidation.Results;

namespace Application.Extensions;

internal  static class ManiputaleObject
{
    public static bool IsValid(this object value)
    {
        return value is not null;
    }

    public static List<string> ResultErrors(this ValidationResult result)
    {
        return result.Errors.Select(s =>
            s.ErrorMessage
        ).ToList();
    }
}