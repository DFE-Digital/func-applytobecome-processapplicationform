using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
using Moq;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Extensions;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class ApplyingSchoolMapperTests
{
    private readonly Mock<IMapper<StagingSchoolLoan, A2BSchoolLoan>> _mockSchoolLoan;
    private readonly Mock<IMapper<StagingSchoolLease, A2BSchoolLease>> _mockSchoolLease;
    private readonly Fixture _fixture;

    public ApplyingSchoolMapperTests()
    {
        _mockSchoolLoan = new();
        _mockSchoolLease = new();
        _fixture = new();
        
        _mockSchoolLoan
            .Setup(x => x.Map(It.IsAny<ICollection<StagingSchoolLoan>>()))
            .Returns(new List<A2BSchoolLoan>());

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

        result.Should().BeAssignableTo<IEnumerable<A2BApplicationApplyingSchool>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplicationApplyingSchool_ShouldReturnMappedCollectionOfA2BApplicationApplyingSchool()
    {
        var applyingSchool = _fixture.Create<StagingApplyingSchool>() with
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

        A2BApplicationApplyingSchool expectedApplyingSchool = new()
        {
            Name = applyingSchool.Name,
            SchoolAddFurtherInformation = applyingSchool.SchoolAddFurtherInformation.ConvertDynamicsIntBool(),
            SchoolAdEqualitiesImpactAssessment = applyingSchool.SchoolAdEqualitiesImpactAssessment.ConvertDynamicsIntBool(),
            SchoolAdEqualitiesImpactAssessmentDetails = applyingSchool.SchoolAdEqualitiesImpactAssessmentDetails,
            SchoolAdFeederSchools = applyingSchool.SchoolAdFeederSchools,
            SchoolAdInspectedButReportNotPublished = applyingSchool.SchoolAdInspectedButReportNotPublished.ConvertDynamicsIntBool(),
            SchoolAdInspectedReportNotPublishedExplain = applyingSchool.SchoolAdInspectedReportNotPublishedExplain,
            SchoolAdSafeguarding = applyingSchool.SchoolAdSafeguarding.ConvertDynamicsIntBool(),
            SchoolAdSafeguardingExplained = applyingSchool.SchoolAdSafeguardingExplained,
            SchoolAdSchoolContributionToTrust = applyingSchool.SchoolAdSchoolContributionToTrust,
            SchoolBuildLandFutureProgramme = applyingSchool.SchoolBuildLandFutureProgramme.ConvertDynamicsIntBool(),
            SchoolBuildLandGrants = applyingSchool.SchoolBuildLandGrants.ConvertDynamicsIntBool(),
            SchoolBuildLandGrantsBody = applyingSchool.SchoolBuildLandGrantsBody,
            SchoolBuildLandOwnerExplained = applyingSchool.SchoolBuildLandOwnerExplained,
            SchoolBuildLandPFIScheme = applyingSchool.SchoolBuildLandPFIScheme.ConvertDynamicsIntBool(),
            SchoolBuildLandPFISchemeType = applyingSchool.SchoolBuildLandPFISchemeType,
            SchoolBuildLandPriorityBuildingProgramme = applyingSchool.SchoolBuildLandPriorityBuildingProgramme.ConvertDynamicsIntBool(),
            SchoolBuildLandSharedFacilities = applyingSchool.SchoolBuildLandSharedFacilities.ConvertDynamicsIntBool(),
            SchoolBuildLandSharedFacilitiesExplained = applyingSchool.SchoolBuildLandSharedFacilitiesExplained,
            SchoolBuildLandWorksPlanned = applyingSchool.SchoolBuildLandWorksPlanned.ConvertDynamicsIntBool(),
            SchoolBuildLandWorksPlannedDate = applyingSchool.SchoolBuildLandWorksPlannedDate,
            SchoolBuildLandWorksPlannedExplained = applyingSchool.SchoolBuildLandWorksPlannedExplained,
            SchoolCapacityAssumptions = applyingSchool.SchoolCapacityAssumptions,
            SchoolCapacityPublishedAdmissionsNumber = applyingSchool.SchoolCapacityPublishedAdmissionsNumber.ToIntOrNull(),
            SchoolCapacityYear1 = applyingSchool.SchoolCapacityYear1,
            SchoolCapacityYear2 = applyingSchool.SchoolCapacityYear2,
            SchoolCapacityYear3 = applyingSchool.SchoolCapacityYear3,
            SchoolConsultationStakeholders = applyingSchool.SchoolConsultationStakeholders.ConvertDynamicsIntBool(),
            SchoolConsultationStakeholdersConsult = applyingSchool.SchoolConsultationStakeholdersConsult,
            SchoolConversionApproverContactEmail = applyingSchool.SchoolConversionApproverContactEmail,
            SchoolConversionApproverContactName = applyingSchool.SchoolConversionApproverContactName,
            SchoolConversionChangeName = applyingSchool.SchoolConversionChangeName.ConvertDynamicsIntBool(),
            SchoolConversionChangeNameValue = applyingSchool.SchoolConversionChangeNameValue,
            SchoolConversionContactChairEmail = applyingSchool.SchoolConversionContactChairEmail,
            SchoolConversionContactChairName = applyingSchool.SchoolConversionContactChairName,
            SchoolConversionContactChairTel = applyingSchool.SchoolConversionContactChairTel,
            SchoolConversionContactHeadEmail = applyingSchool.SchoolConversionContactChairEmail,
            SchoolConversionContactHeadName = applyingSchool.SchoolConversionContactHeadName,
            SchoolConversionContactHeadTel = applyingSchool.SchoolConversionContactChairTel,
            SchoolConversionContactRole = applyingSchool.SchoolConversionContactRole.ConvertApplicationRole(),
            SchoolConversionMainContactOtherRole = applyingSchool.SchoolConversionMainContactOtherRole,
            SchoolConversionMainContactOtherEmail = applyingSchool.SchoolConversionMainContactOtherEmail,
            SchoolConversionMainContactOtherName = applyingSchool.SchoolConversionMainContactOtherName,
            SchoolConversionMainContactOtherTelephone = applyingSchool.SchoolConversionMainContactOtherTelephone,
            SchoolConversionReasonsForJoining = applyingSchool.SchoolConversionReasonsForJoining,
            SchoolConversionTargetDateDifferent = applyingSchool.SchoolConversionTargetDateDifferent.ConvertDynamicsIntBool(),
            SchoolConversionTargetDateDate = applyingSchool.SchoolConversionTargetDateDate,
            SchoolConversionTargetDateExplained = applyingSchool.SchoolConversionTargetDateExplained,
            SchoolDeclarationBodyAgree = applyingSchool.SchoolDeclarationBodyAgree.ConvertDynamicsIntBool(),
            SchoolDeclarationSignedByEmail = applyingSchool.SchoolDeclarationSignedByEmail,
            SchoolDeclarationSignedById = applyingSchool.SchoolDeclarationSignedById,
            SchoolDeclarationSignedByName = applyingSchool.SchoolDeclarationSignedByName,
            SchoolDeclarationTeacherChair = applyingSchool.SchoolDeclarationTeacherChair.ConvertDynamicsIntBool(),
            SchoolFaithSchool = applyingSchool.SchoolFaithSchool.ConvertDynamicsIntBool(),
            SchoolFaithSchoolDioceseName = applyingSchool.SchoolFaithSchoolDioceseName,
            SchoolFinancialInvestigations = applyingSchool.SchoolFinancialInvestigations.ConvertDynamicsIntBool(),
            SchoolFinancialInvestigationsExplain = applyingSchool.SchoolFinancialInvestigationsExplain,
            SchoolFinancialInvestigationsTrustAware = applyingSchool.SchoolFinancialInvestigationsTrustAware.ConvertDynamicsIntBool(),
            SchoolFurtherInformation = applyingSchool.SchoolFurtherInformation,
            SchoolLaClosurePlans = applyingSchool.SchoolLaClosurePlans.ConvertDynamicsIntBool(),
            SchoolLaClosurePlansExplain = applyingSchool.SchoolLaClosurePlansExplain,
            SchoolLaReorganization = applyingSchool.SchoolLaReorganization.ConvertDynamicsIntBool(),
            SchoolLaReorganizationExplain = applyingSchool.SchoolLaReorganizationExplain,
            SchoolPFYCapitalForward = applyingSchool.SchoolPFYCapitalForward,
            SchoolPFYCapitalForwardStatusExplained = applyingSchool.SchoolPFYCapitalForwardStatusExplained,
            SchoolPFYCapitalIsDeficit = applyingSchool.SchoolPFYCapitalSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolPFYEndDate = applyingSchool.SchoolPFYEndDate,
            SchoolPFYRevenue = applyingSchool.SchoolPFYRevenue,
            SchoolPFYRevenueIsDeficit = applyingSchool.SchoolPFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolPFYRevenueStatusExplained = applyingSchool.SchoolPFYRevenueStatusExplained,
            SchoolCFYCapitalForward = applyingSchool.SchoolCFYCapitalForward,
            SchoolCFYCapitalForwardStatusExplained = applyingSchool.SchoolCFYCapitalForwardStatusExplained,
            SchoolCFYCapitalIsDeficit = applyingSchool.SchoolCFYCapitalSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolCFYEndDate = applyingSchool.SchoolCFYEndDate,
            SchoolCFYRevenue = applyingSchool.SchoolCFYRevenue,
            SchoolCFYRevenueIsDeficit = applyingSchool.SchoolCFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolCFYRevenueStatusExplained = applyingSchool.SchoolCFYRevenueStatusExplained,
            SchoolNFYCapitalForward = applyingSchool.SchoolNFYCapitalForward,
            SchoolNFYCapitalForwardStatusExplained = applyingSchool.SchoolNFYCapitalForwardStatusExplained,
            SchoolNFYCapitalIsDeficit = applyingSchool.SchoolNFYCapitalSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolNFYEndDate = applyingSchool.SchoolNFYEndDate,
            SchoolNFYRevenue = applyingSchool.SchoolNFYRevenue,
            SchoolNFYRevenueIsDeficit = applyingSchool.SchoolNFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolNFYRevenueStatusExplained = applyingSchool.SchoolNFYRevenueStatusExplained,
            SchoolPartOfFederation = applyingSchool.SchoolPartOfFederation.ConvertDynamicsIntBool(),
            SchoolSACREExemption = applyingSchool.SchoolSACREExemption.ConvertDynamicsIntBool(),
            SchoolSACREExemptionEndDate = applyingSchool.SchoolSACREExemptionEndDate,
            SchoolSupportedFoundation = applyingSchool.SchoolSupportedFoundation.ConvertDynamicsIntBool(),
            SchoolSupportedFoundationBodyName = applyingSchool.SchoolSupportedFoundationBodyName,
            SchoolSupportGrantFundsPaidTo = applyingSchool.SchoolSupportGrantFundsPaidTo.ConvertFundsPaidTo(),
            SchoolLeases = new List<A2BSchoolLease>(),
            SchoolLoans = new List<A2BSchoolLoan>(),
        };

        List<StagingApplyingSchool> applyingSchools = new() {applyingSchool};
        List<A2BApplicationApplyingSchool> expected = new() {expectedApplyingSchool};
        
        ApplyingSchoolMapper mapper = new(_mockSchoolLease.Object, _mockSchoolLoan.Object);
        var result = mapper.Map(applyingSchools);

        result.Should().BeEquivalentTo(expected);
    }
}