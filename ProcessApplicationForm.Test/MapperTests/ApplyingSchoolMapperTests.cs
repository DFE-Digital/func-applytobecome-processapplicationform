using System.Collections.Generic;
using FluentAssertions;
using Moq;
using ProcessApplicationForm.Test.Data;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class ApplyingSchoolMapperTests
{
    private readonly ApplyingSchoolMapper _mapper;
    
    public ApplyingSchoolMapperTests()
    {
        Mock<IMapper<StagingSchoolLoan, A2BSchoolLoan>> mockSchoolLoan = new();
        Mock<IMapper<StagingSchoolLease, A2BSchoolLease>> mockSchoolLease = new();
        
        mockSchoolLoan
            .Setup(x => x.Map(It.IsAny<ICollection<StagingSchoolLoan>>()))
            .Returns(new HashSet<A2BSchoolLoan>());
        mockSchoolLease
            .Setup(x => x.Map(It.IsAny<ICollection<StagingSchoolLease>>()))
            .Returns(new HashSet<A2BSchoolLease>());
        
        _mapper = new(mockSchoolLease.Object, mockSchoolLoan.Object);
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplicationApplyingSchool_ShouldReturnCollectionOfTypeA2BApplicationApplyingSchool()
    {
        List<StagingApplyingSchool> stagingApplyingSchools = new() {TestData.StagingApplyingSchoolData};

        var result = _mapper.Map(stagingApplyingSchools);

        result.Should().BeAssignableTo<IEnumerable<A2BApplicationApplyingSchool>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplicationApplyingSchool_ShouldReturnMappedCollectionOfA2BApplicationApplyingSchool()
    {
        List<StagingApplyingSchool> stagingApplyingSchools = new() { TestData.StagingApplyingSchoolData};
        List<A2BApplicationApplyingSchool> expected = new() { TestData.A2BApplicationApplyingSchoolData };
        
        var result = _mapper.Map(stagingApplyingSchools);

        result.Should().BeEquivalentTo(expected);
    }
}