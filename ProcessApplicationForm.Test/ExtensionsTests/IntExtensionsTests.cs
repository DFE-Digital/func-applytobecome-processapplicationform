using FluentAssertions;
using ProcessApplicationFormFunction.Extensions;
using Xunit;

namespace ProcessApplicationForm.Test.ExtensionsTests;

public class IntExtensionsTests
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

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(907660000, "Headteacher")]
    [InlineData(907660001, "ChairGovernor")]
    [InlineData(907660002, "Other")]
    [InlineData(null, null)]
    public void ConvertApplicationRole_ReturnsExpectedValueFromInlineData(int? input, string expected)
    {
        var result = input.ConvertApplicationRole();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(907660000, true)]
    [InlineData(907660001, false)]
    [InlineData(null, null)]
    public void ConvertDynamicsIntBool_ReturnsExpectedValueFromInlineData(int? input, bool? expected)
    {
        var result = input.ConvertDynamicsIntBool();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(907660000, "School")]
    [InlineData(907660001, "Trust")]
    [InlineData(null, null)]
    public void ConvertFundsPaidTo_ReturnsExpectedValueFromInlineData(int? input, string expected)
    {
        var result = input.ConvertFundsPaidTo();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(907660000, true)]
    [InlineData(907660001, true)]
    [InlineData(907660002, false)]
    public void ConvertDynamicsEqualitiesImpactAssessmentIntBool_ReturnsExpectedValueFromInlineData(int? input, bool expected)
    {
        var result = input.ConvertDynamicsEqualitiesImpactAssessmentIntBool();

        result.Should().Be(expected);
    }


    [Theory]
    [InlineData(907660000, "That the Secretary of State's decision is unlikely to disproportionately affect any particular person or group who share protected characteristics")]
    [InlineData(907660001, "That there are some impacts but on balance the changes will not disproportionately affect any particular person or group who share protected characteristics")]
    [InlineData(907660002, null)]
    public void ConvertEqualitiesImpactAssessmentDetails_ReturnsExpectedValueFromInlineData(int? input, string expected)
    {
        var result = input.ConvertEqualitiesImpactAssessmentDetails();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(907660000, true)]
    [InlineData(907660001, null)]
    [InlineData(907660002, false)]
    public void ConvertChangesToTrust_ReturnsExpectedValueFromInlineData(int? input, bool? expected) 
    {
        var result = input.ConvertChangesToTrust();

        result.Should().Be(expected);
    }
}