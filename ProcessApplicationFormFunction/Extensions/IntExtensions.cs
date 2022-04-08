namespace ProcessApplicationFormFunction.Extensions;

public static class IntExtensions
{
    public static bool? ConvertSurplusOrDeficit(this int? value) => value switch
    {
        907660000 => false,
        907660001 => true,
        _ => null
    };
    
    public static string ConvertApplicationType(this int? value) => value switch
    {
        100000001 => "JoinMat",
        907660000 => "FormMat",
        907660001 => "FormSat",
        _ => null
    };
    
    public static string ConvertApplicationRole(this int? role) => role switch
    {
        907660000 => "Headteacher",
        907660001 => "ChairGovernor",
        907660002 => "Other",
        _ => null
    };
    
    public static bool? ConvertDynamicsIntBool(this int? value) => value switch
    {
        907660000 => true,
        907660001 => false,
        _ => null
    };

    public static string ConvertFundsPaidTo(this int? paid) => paid switch
    {
        907660000 => "School",
        907660001 => "Trust",
        _ => null
    };
}