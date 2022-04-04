using System.Collections.Generic;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class SchoolLeaseMapperTests
{
    [Fact]
    public void Map_WhenGivenCollectionOfStagingSchoolLease_ShouldReturnCollectionOfTypeIEnumerableA2BSchoolLease()
    {
        IMapper<StagingSchoolLease, A2BSchoolLease> mapper = new SchoolLeaseMapper();
        List<StagingSchoolLease> source = new();

        var result = mapper.Map(source);

        Assert.IsAssignableFrom<IEnumerable<A2BSchoolLease>>(result);
    }
}