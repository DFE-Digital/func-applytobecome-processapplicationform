using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
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
        _mockSchoolLoan
            .Setup(x => x.Map(It.IsAny<ICollection<StagingSchoolLoan>>()))
            .Returns(new List<A2BSchoolLoan>());
        _mockSchoolLease = new();
        _mockSchoolLease
            .Setup(x => x.Map(It.IsAny<ICollection<StagingSchoolLease>>()))
            .Returns(new List<A2BSchoolLease>());

    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplicationApplyingSchool_ShouldReturnCollectionOfTypeA2BApplicationApplyingSchool()
    {
        var mapper = new ApplyingSchoolMapper(_mockSchoolLease.Object, _mockSchoolLoan.Object);
        List<StagingApplyingSchool> source = new();

        var result = mapper.Map(source);

        Assert.IsAssignableFrom<IEnumerable<A2BApplicationApplyingSchool>>(result);
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplicationApplyingSchool_ShouldReturnMappedCollectionOfA2BApplicationApplyingSchool()
    {
        Fixture fixture = new();
        var stagingApplicationApplyingSchool = fixture.Create<StagingApplyingSchool>() with
        {
            SchoolDeclarationBodyAgree = 907660000,
            SchoolDeclarationTeacherChair = 907660000,
            SchoolConversionTargetDateDifferent = 907660000,
            SchoolConversionChangeName = 907660000,
            SchoolAdInspectedButReportNotPublished = 907660000,
            SchoolLaReorganization = 907660000,
            SchoolLaClosurePlans = 907660000,
            SchoolPartOfFederation = 907660000,
            SchoolAddFurtherInformation = 907660000,
            SchoolAdSafeguarding = 907660000,
            SchoolSACREExemption = 907660000,
            SchoolSupportedFoundation = 907660000,
            SchoolAdEqualitiesImpactAssessment = 907660000,
            SchoolFinancialInvestigations = 907660000,
            SchoolFinancialInvestigationsTrustAware = 907660000,
            SchoolBuildLandSharedFacilities = 907660000,
            SchoolBuildLandWorksPlanned = 907660000,
            SchoolBuildLandGrants = 907660000,
            SchoolBuildLandPriorityBuildingProgramme = 907660000,
            SchoolBuildLandFutureProgramme = 907660000,
            SchoolBuildLandPFIScheme = 907660000,
            SchoolConsultationStakeholders = 907660000,
            SchoolPFYCapitalSurplusOrDeficit = 907660000,
            SchoolPFYRevenueSurplusOrDeficit = 907660000,
            SchoolCFYCapitalSurplusOrDeficit = 907660000,
            SchoolCFYRevenueSurplusOrDeficit = 907660000,
            SchoolNFYCapitalSurplusOrDeficit = 907660000,
            SchoolNFYRevenueSurplusOrDeficit = 907660000,
            SchoolSupportGrantFundsPaidTo = 907660000,
            SchoolConversionContactRole = 90760000
        };
        
        List<StagingApplyingSchool> applyingSchool = new() { stagingApplicationApplyingSchool };
        List<A2BApplicationApplyingSchool> expectedResult = new()
        {
            //new()
            //{
            //    SchoolDeclarationBodyAgree
            //}
        };

        ApplyingSchoolMapper mapper = new(_mockSchoolLease.Object, _mockSchoolLoan.Object);
        var result = mapper.Map(applyingSchool);

        result.Should().BeEquivalentTo(expectedResult);
    }
}