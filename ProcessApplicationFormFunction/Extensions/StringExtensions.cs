namespace ProcessApplicationFormFunction.Extensions;

public static class StringExtensions
{
    public static int? ToIntOrNull(this string value) => int.TryParse(value, out var result) ? result : null;
}