using System.Collections;
using System.Collections.Generic;
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

    [Theory]
    [ClassData(typeof(DecimalTestDataGenerator))]
    public static void ToDecimalOrNull_ReturnsExpectedValueFromInlineData(string input, decimal? expected)
    {
        var result = input.ToDecimalOrNull();

        result.Should().Be(expected);
    }
}

public class DecimalTestDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[] {"-10.101", -10.101M},
        new object[] {"0.00", 0m},
        new object[] {"10.101", 10.101m},
        new object[] {null!, null!},
        new object[] {"", null!},
        new object[] {"   ", null!},
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

    