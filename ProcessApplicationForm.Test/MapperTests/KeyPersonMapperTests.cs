using System.Collections.Generic;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class KeyPersonMapperTests
{
    [Fact]
    public void Map_WhenGivenCollectionOfStagingKeyPerson_ShouldReturnCollectionOfTypeA2BApplicationKeyPerson()
    {
        IMapper<StagingKeyPerson, A2BApplicationKeyPerson> mapper = new KeyPersonMapper();
        List<StagingKeyPerson> source = new();

        var result = mapper.Map(source);

        Assert.IsAssignableFrom<IEnumerable<A2BApplicationKeyPerson>>(result);
    }
}