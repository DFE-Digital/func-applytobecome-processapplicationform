namespace ProcessApplicationFormFunction.Extensions;

public static class BoolExtensions
{
    public static string ToYesNoString(this bool? value)
    {
        if(!value.HasValue) return string.Empty;
        return value == true ? "Yes" : "No";
    }
}