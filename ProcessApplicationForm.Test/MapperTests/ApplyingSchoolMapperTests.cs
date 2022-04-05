using System.Collections.Generic;
using Moq;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class ApplyingSchoolMapperTests
{
    private readonly Mock<IMapper<StagingSchoolLoan, A2BSchoolLoan>> _mockSchoolLoan;
    private readonly Mock<IMapper<StagingSchoolLease, A2BSchoolLease>> _mockSchoolLease;

    public ApplyingSchoolMapperTests()
    {
        _mockSchoolLoan = new();
        _mockSchoolLease = new();
    }
    
    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplicationApplyingSchool_ShouldReturnCollectionOfTypeA2BApplicationApplyingSchool()
    {
        var mapper = new ApplyingSchoolMapper(_mockSchoolLease.Object, _mockSchoolLoan.Object);
        List<StagingApplyingSchool> source = new();

        var result = mapper.Map(source);

        Assert.IsAssignableFrom<IEnumerable<A2BApplicationApplyingSchool>>(result);
    }
}