using FluentAssertions;
using ProcessApplicationFormFunction.Extensions;
using Xunit;

namespace ProcessApplicationForm.Test.ExtensionsTests;

public static class StringExtensionTests
{

    [Theory]
    [InlineData("-2147483648", -2147483648)]
    [InlineData("-10", -10)]
    [InlineData("0", 0)]
    [InlineData("10", 10)]
    [InlineData("2147483647", 2147483647)]
    [InlineData("-2147483649", null)]
    [InlineData("2147483648", null)]
    [InlineData(null, null)]
    [InlineData("", null)]
    [InlineData("   ", null)]
    public static void ToIntOrNull_ReturnsExpectedValueFromInlineData(string input, int? expected)
    {
        var result = input.ToIntOrNull();

        result.Should().Be(expected);
    }
}
    