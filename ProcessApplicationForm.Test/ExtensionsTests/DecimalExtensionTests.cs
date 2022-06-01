using FluentAssertions;
using ProcessApplicationFormFunction.Extensions;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ProcessApplicationForm.Test.ExtensionsTests
{
    public class DecimalGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1.0M, true, -1.0M };
            yield return new object[] { 2.0M, false, 2.0M };
            yield return new object[] { null, true, null };
            yield return new object[] { 1.0M, null, null };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class DecimalExtensionTests
    {
        [Theory]
        [ClassData(typeof(DecimalGenerator))]
        public void GivenIsDeficitParameter_ReturnsCorrectDecimal(decimal? value, bool? isDeficit, decimal? expected)
        {
            value.ConvertDeficitAmountToNegativeValue(isDeficit).Should().Be(expected);
        }
    }
}
