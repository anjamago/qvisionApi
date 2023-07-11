namespace Application.Extensions;

internal  static class ManiputaleObject
{
    public static bool IsValid(this object value)
    {
        return value is not null;
    }
}