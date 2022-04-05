using ProcessApplicationFormFunction.Extensions;
using Xunit;

namespace ProcessApplicationForm.Test.ExtensionsTests;

public class StringExtensionsTests
{
    [Theory]
    [InlineData(907660000, false)]
    [InlineData(907660001, true)]
    [InlineData(null, null)]
    public void SurplusOrDeficitToNullableBool_ReturnsExpectedValueFromInlineData(int? input, bool? expected)
    {
        var result = input.ConvertSurplusOrDeficit();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(100000001, "JoinMat")]
    [InlineData(907660000, "FormMat")]
    [InlineData(907660001, "FormSat")]
    [InlineData(null, null)]
    public void ConvertApplicationType_ReturnsExpectedValueFromInlineData(int? input, string expected)
    {
        var result = input.ConvertApplicationType();
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(907660000, "Headteacher")]
    [InlineData(907660001, "ChairGovernor")]
    [InlineData(907660002, "Other")]
    [InlineData(null, null)]
    public void ConvertApplicationRole_ReturnsExpectedValueFromInlineData(int? input, string expected)
    {
        var result = input.ConvertApplicationRole();
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(907660000, true)]
    [InlineData(907660001, false)]
    [InlineData(null, null)]
    public void ConvertDynamicsIntBool_ReturnsExpectedValueFromInlineData(int? input, bool? expected)
    {
        var result = input.ConvertDynamicsIntBool();
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(907660000, "School")]
    [InlineData(907660001, "Trust")]
    [InlineData(null, null)]
    public void ConvertFundsPaidTo_ReturnsExpectedValueFromInlineData(int? input, string expected)
    {
        var result = input.ConvertFundsPaidTo();
        
        Assert.Equal(expected, result);
    }
}