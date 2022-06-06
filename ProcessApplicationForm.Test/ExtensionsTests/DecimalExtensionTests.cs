using FluentAssertions;
using ProcessApplicationFormFunction.Extensions;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ProcessApplicationForm.Test.ExtensionsTests
{
    public class TestData
    {
        public decimal? Value { get; set; }
        public bool? IsDeficit { get; set; }
        public decimal? Expected { get; set; }
    }
    
    public class DecimalGenerator : IEnumerable<TestData>
    {
        public IEnumerator<TestData> GetEnumerator()
        {
            yield return new () { Value=1.0M, IsDeficit=true, Expected=-12.9M };
            yield return new() { Value=2.0M, IsDeficit=false, Expected=2.0M };
            yield return new() { Value=null, IsDeficit=true, Expected=null };
            yield return new() { Value=1.0M, IsDeficit=null, Expected=null };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class DecimalExtensionTests
    {
        [Theory]
        [InlineData(1.0, true, -1.0)]
        [InlineData(2.0, false, 2.0)]
        [InlineData(1.0, null, null)]
        [InlineData(null, true, null)]
        public void GivenIsDeficitParameter_ReturnsCorrectDecimal(double? value, bool? isDeficit, double? expected)
        {
            value.As<decimal?>().ConvertDeficitAmountToNegativeValue(isDeficit).Should().Be(expected.As<decimal?>());
        }
    }
}
