using FluentAssertions;
using ProcessApplicationFormFunction.Extensions;
using Xunit;

namespace ProcessApplicationForm.Test.ExtensionsTests;

public class BoolExtensionTests
{
    [Theory]
    [InlineData(true, "Yes")]
    [InlineData(false, "No")]
    [InlineData(null, "")]
    public void _ReturnsExpectedValueFromInlineData(bool? input, string expected)
    {
        var result = input.ToYesNoString();

        result.Should().Be(expected);
    }
}