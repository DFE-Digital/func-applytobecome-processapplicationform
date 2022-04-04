using System.Collections.Generic;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class SchoolLoanMapperTests
{
    [Fact]
    public void Map_WhenGivenCollectionOfStagingSchoolLoan_ShouldReturnCollectionOfTypeIEnumerableA2BSchoolLoan()
    {
        IMapper<StagingSchoolLoan, A2BSchoolLoan> mapper = new SchoolLoanMapper();
        List<StagingSchoolLoan> source = new();

        var result = mapper.Map(source);

        Assert.IsAssignableFrom<IEnumerable<A2BSchoolLoan>>(result);
    }
}