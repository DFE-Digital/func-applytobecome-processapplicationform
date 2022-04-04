using System.Collections.Generic;
using Moq;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class ApplicationMapperTests
{
    private readonly Mock<IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool>> _mockApplyingSchoolMapper;
    private readonly Mock<IMapper<StagingKeyPerson, A2BApplicationKeyPerson>> _mockKeyPersonMapper;
    

    public ApplicationMapperTests()
    {
        _mockApplyingSchoolMapper = new();
        _mockApplyingSchoolMapper
            .Setup(m => m.Map(It.IsAny<ICollection<StagingApplyingSchool>>()))
            .Returns(new List<A2BApplicationApplyingSchool>());

        _mockKeyPersonMapper = new();
        _mockKeyPersonMapper
            .Setup(m => m.Map(It.IsAny<ICollection<StagingKeyPerson>>()))
            .Returns(new List<A2BApplicationKeyPerson>());
    }
    
    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplication_ShouldReturnCollectionOfTypeA2BApplication()
    {
        IMapper<StagingApplication, A2BApplication> mapper = 
            new ApplicationMapper(_mockApplyingSchoolMapper.Object, _mockKeyPersonMapper.Object);
        
        List<StagingApplication> source = new();

        var result = mapper.Map(source);

        Assert.IsAssignableFrom<IEnumerable<A2BApplication>>(result);
    }
}