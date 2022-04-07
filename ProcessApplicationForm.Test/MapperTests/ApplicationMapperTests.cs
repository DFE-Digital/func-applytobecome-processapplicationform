using System.Collections.Generic;
using FluentAssertions;
using Moq;
using ProcessApplicationForm.Test.Data;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class ApplicationMapperTests
{
    private readonly ApplicationMapper _mapper;

    public ApplicationMapperTests()
    {
        Mock<IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool>> mockApplyingSchoolMapper = new();
        Mock<IMapper<StagingKeyPerson, A2BApplicationKeyPerson>> mockKeyPersonMapper = new();
        
        mockApplyingSchoolMapper
            .Setup(m => m.Map(It.IsAny<ICollection<StagingApplyingSchool>>()))
            .Returns(new HashSet<A2BApplicationApplyingSchool>());
        mockKeyPersonMapper
            .Setup(m => m.Map(It.IsAny<ICollection<StagingKeyPerson>>()))
            .Returns(new HashSet<A2BApplicationKeyPerson>());
        
        _mapper = new(mockApplyingSchoolMapper.Object, mockKeyPersonMapper.Object);
    }
    
    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplication_ShouldReturnCollectionOfTypeA2BApplication()
    {
        List<StagingApplication> stagingApplications =new() {TestData.StagingApplicationData};

        var result = _mapper.Map(stagingApplications);

        result.Should().BeAssignableTo<IEnumerable<A2BApplication>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplication_ShouldReturnMappedCollectionOfA2BApplication()
    {
        List<StagingApplication> stagingApplications = new() {TestData.StagingApplicationData};
        List<A2BApplication> expected = new() {TestData.A2BApplicationData};
        
        var result = _mapper.Map(stagingApplications);

        result.Should().BeEquivalentTo(expected);
    }
}