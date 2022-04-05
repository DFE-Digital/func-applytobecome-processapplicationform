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
        fixture.Customize<StagingApplyingSchool>(custom =>
        {
            custom.With(p => p.SchoolDeclarationBodyAgree, 907660000);
            custom.With(p => p.SchoolDeclarationTeacherChair, 907660000);
            custom.With(p => p.SchoolConversionTargetDateDifferent, 907660000);
            custom.With(p => p.SchoolConversionChangeName, 907660000);
            custom.With(p => p.SchoolAdInspectedButReportNotPublished, 907660000);
            custom.With(p => p.SchoolLaReorganization, 907660000);
            custom.With(p => p.SchoolLaClosurePlans, 907660000);
            custom.With(p => p.SchoolPartOfFederation, 907660000);
            custom.With(p => p.SchoolAddFurtherInformation, 907660000);
            custom.With(p => p.SchoolAdSafeguarding, 907660000);
            custom.With(p => p.SchoolSACREExemption, 907660000);
            custom.With(p => p.SchoolSupportedFoundation, 907660000);
            custom.With(p => p.SchoolAdEqualitiesImpactAssessment, 907660000);
            custom.With(p => p.SchoolFinancialInvestigations, 907660000);
            custom.With(p => p.SchoolFinancialInvestigationsTrustAware, 907660000);
            custom.With(p => p.SchoolBuildLandSharedFacilities, 907660000);
            custom.With(p => p.SchoolBuildLandWorksPlanned, 907660000);
            custom.With(p => p.SchoolBuildLandGrants, 907660000);
            custom.With(p => p.SchoolBuildLandPriorityBuildingProgramme, 907660000);
            custom.With(p => p.SchoolBuildLandFutureProgramme, 907660000);
            custom.With(p => p.SchoolBuildLandPFIScheme, 907660000);
            custom.With(p => p.SchoolConsultationStakeholders, 907660000);
            custom.With(p => p.SchoolBuildLandPFIScheme, 907660000);
            custom.With(p => p.SchoolPFYCapitalSurplusOrDeficit, 907660000);
            custom.With(p => p.SchoolPFYRevenueSurplusOrDeficit, 907660000);
            custom.With(p => p.SchoolCFYCapitalSurplusOrDeficit, 907660000);
            custom.With(p => p.SchoolCFYRevenueSurplusOrDeficit, 907660000);
            custom.With(p => p.SchoolNFYCapitalSurplusOrDeficit, 907660000);
            custom.With(p => p.SchoolNFYRevenueSurplusOrDeficit, 907660000);

            return custom;
        });

        var stagingApplicationApplyingSchool = fixture.Create<StagingApplyingSchool>();
           
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