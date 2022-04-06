using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
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
            // document links missing from staging model - remove from A2BApplicationApplyingSchool model?
            new()
            {
                Name = stagingApplyingSchool.Name,
                SchoolAddFurtherInformation = stagingApplyingSchool.SchoolAddFurtherInformation.ConvertDynamicsIntBool(),
                SchoolAdEqualitiesImpactAssessment = stagingApplyingSchool.SchoolAdEqualitiesImpactAssessment.ConvertDynamicsIntBool(),
                SchoolAdEqualitiesImpactAssessmentDetails = stagingApplyingSchool.SchoolAdEqualitiesImpactAssessmentDetails,
                SchoolAdFeederSchools = stagingApplyingSchool.SchoolAdFeederSchools,
                SchoolAdInspectedButReportNotPublished = stagingApplyingSchool.SchoolAdInspectedButReportNotPublished.ConvertDynamicsIntBool(),
                SchoolAdInspectedReportNotPublishedExplain = stagingApplyingSchool.SchoolAdInspectedReportNotPublishedExplain,
                SchoolAdSafeguarding = stagingApplyingSchool.SchoolAdSafeguarding.ConvertDynamicsIntBool(),
                SchoolAdSafeguardingExplained = stagingApplyingSchool.SchoolAdSafeguardingExplained,
                SchoolAdSchoolContributionToTrust = stagingApplyingSchool.SchoolAdSchoolContributionToTrust,
                SchoolBuildLandFutureProgramme = stagingApplyingSchool.SchoolBuildLandFutureProgramme.ConvertDynamicsIntBool(),
                SchoolBuildLandGrants = stagingApplyingSchool.SchoolBuildLandGrants.ConvertDynamicsIntBool(),
                SchoolBuildLandGrantsBody = stagingApplyingSchool.SchoolBuildLandGrantsBody,
                SchoolBuildLandOwnerExplained = stagingApplyingSchool.SchoolBuildLandOwnerExplained,
                SchoolBuildLandPFIScheme = stagingApplyingSchool.SchoolBuildLandPFIScheme.ConvertDynamicsIntBool(),
                SchoolBuildLandPFISchemeType = stagingApplyingSchool.SchoolBuildLandPFISchemeType,
                SchoolBuildLandPriorityBuildingProgramme = stagingApplyingSchool.SchoolBuildLandPriorityBuildingProgramme.ConvertDynamicsIntBool(),
                SchoolBuildLandSharedFacilities = stagingApplyingSchool.SchoolBuildLandSharedFacilities.ConvertDynamicsIntBool(),
                SchoolBuildLandSharedFacilitiesExplained = stagingApplyingSchool.SchoolBuildLandSharedFacilitiesExplained,
                SchoolBuildLandWorksPlanned = stagingApplyingSchool.SchoolBuildLandWorksPlanned.ConvertDynamicsIntBool(),
                SchoolBuildLandWorksPlannedDate = stagingApplyingSchool.SchoolBuildLandWorksPlannedDate,
                SchoolBuildLandWorksPlannedExplained = stagingApplyingSchool.SchoolBuildLandWorksPlannedExplained,
                SchoolCapacityAssumptions = stagingApplyingSchool.SchoolCapacityAssumptions,
                SchoolCapacityPublishedAdmissionsNumber = int.Parse(stagingApplyingSchool.SchoolCapacityPublishedAdmissionsNumber), // TODO
                SchoolCapacityYear1 = stagingApplyingSchool.SchoolCapacityYear1,
                SchoolCapacityYear2 = stagingApplyingSchool.SchoolCapacityYear2,
                SchoolCapacityYear3 = stagingApplyingSchool.SchoolCapacityYear3,
                SchoolConsultationStakeholders = stagingApplyingSchool.SchoolConsultationStakeholders.ConvertDynamicsIntBool(),
                SchoolConsultationStakeholdersConsult = stagingApplyingSchool.SchoolConsultationStakeholdersConsult,
                SchoolConversionApproverContactEmail = stagingApplyingSchool.SchoolConversionApproverContactEmail,
                SchoolConversionApproverContactName = stagingApplyingSchool.SchoolConversionApproverContactName,
                SchoolConversionChangeName = stagingApplyingSchool.SchoolConversionChangeName.ConvertDynamicsIntBool(),
                SchoolConversionChangeNameValue = stagingApplyingSchool.SchoolConversionChangeNameValue,
                SchoolConversionContactChairEmail = stagingApplyingSchool.SchoolConversionContactChairEmail,
                SchoolConversionContactChairName = stagingApplyingSchool.SchoolConversionContactChairName,
                SchoolConversionContactChairTel = stagingApplyingSchool.SchoolConversionContactChairTel,
                SchoolConversionContactHeadEmail = stagingApplyingSchool.SchoolConversionContactChairEmail,
                SchoolConversionContactHeadName = stagingApplyingSchool.SchoolConversionContactHeadName,
                SchoolConversionContactHeadTel = stagingApplyingSchool.SchoolConversionContactChairTel,
                SchoolConversionContactRole = stagingApplyingSchool.SchoolConversionMainContactOther.ConvertApplicationRole(),
                SchoolConversionMainContactOtherRole = stagingApplyingSchool.SchoolConversionMainContactOtherRole,
                SchoolConversionMainContactOtherEmail = stagingApplyingSchool.SchoolConversionMainContactOtherEmail,
                SchoolConversionMainContactOtherName = stagingApplyingSchool.SchoolConversionMainContactOtherName,
                SchoolConversionMainContactOtherTelephone = stagingApplyingSchool.SchoolConversionMainContactOtherTelephone,
                SchoolConversionReasonsForJoining = stagingApplyingSchool.SchoolConversionReasonsForJoining,
                SchoolConversionTargetDateDifferent = stagingApplyingSchool.SchoolConversionTargetDateDifferent.ConvertDynamicsIntBool(),
                SchoolConversionTargetDateDate = stagingApplyingSchool.SchoolConversionTargetDateDate,
                SchoolConversionTargetDateExplained = stagingApplyingSchool.SchoolConversionTargetDateExplained,
                SchoolDeclarationBodyAgree = stagingApplyingSchool.SchoolDeclarationBodyAgree.ConvertDynamicsIntBool(),
                SchoolDeclarationSignedByEmail = stagingApplyingSchool.SchoolDeclarationSignedByEmail,
                SchoolDeclarationSignedById = stagingApplyingSchool.SchoolDeclarationSignedById,
                SchoolDeclarationSignedByName = stagingApplyingSchool.SchoolDeclarationSignedByName,
                SchoolDeclarationTeacherChair = stagingApplyingSchool.SchoolDeclarationTeacherChair.ConvertDynamicsIntBool(),
                SchoolFaithSchool = stagingApplyingSchool.SchoolFaithSchool.ConvertDynamicsIntBool(),
                SchoolFaithSchoolDioceseName = stagingApplyingSchool.SchoolFaithSchoolDioceseName,
                SchoolFinancialInvestigations = stagingApplyingSchool.SchoolFinancialInvestigations.ConvertDynamicsIntBool(),
                SchoolFinancialInvestigationsExplain = stagingApplyingSchool.SchoolFinancialInvestigationsExplain,
                SchoolFinancialInvestigationsTrustAware = stagingApplyingSchool.SchoolFinancialInvestigationsTrustAware.ConvertDynamicsIntBool(),
                SchoolFurtherInformation = stagingApplyingSchool.SchoolFurtherInformation,
                SchoolLaClosurePlans = stagingApplyingSchool.SchoolLaClosurePlans.ConvertDynamicsIntBool(),
                SchoolLaClosurePlansExplain = stagingApplyingSchool.SchoolLaClosurePlansExplain,
                SchoolLaReorganization = stagingApplyingSchool.SchoolLaReorganization.ConvertDynamicsIntBool(),
                SchoolLaReorganizationExplain = stagingApplyingSchool.SchoolLaReorganizationExplain,
                SchoolPFYCapitalForward = stagingApplyingSchool.SchoolPFYCapitalForward,
                SchoolPFYCapitalForwardStatusExplained = stagingApplyingSchool.SchoolPFYCapitalForwardStatusExplained,

                SchoolPFYCapitalIsDeficit = stagingApplyingSchool.SchoolPFYCapitalSurplusOrDeficit.ConvertSurplusOrDeficit(),
                SchoolPFYEndDate = stagingApplyingSchool.SchoolPFYEndDate,
                SchoolPFYRevenue = stagingApplyingSchool.SchoolPFYRevenue,
                SchoolPFYRevenueIsDeficit = stagingApplyingSchool.SchoolPFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
                SchoolPFYRevenueStatusExplained = stagingApplyingSchool.SchoolPFYRevenueStatusExplained,

                SchoolCFYCapitalForward = stagingApplyingSchool.SchoolCFYCapitalForward,
                SchoolCFYCapitalForwardStatusExplained = stagingApplyingSchool.SchoolCFYCapitalForwardStatusExplained,
                SchoolCFYCapitalIsDeficit = stagingApplyingSchool.SchoolCFYCapitalSurplusOrDeficit.ConvertSurplusOrDeficit(),
                SchoolCFYEndDate = stagingApplyingSchool.SchoolCFYEndDate,
                SchoolCFYRevenue = stagingApplyingSchool.SchoolCFYRevenue,
                SchoolCFYRevenueIsDeficit = stagingApplyingSchool.SchoolCFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
                SchoolCFYRevenueStatusExplained = stagingApplyingSchool.SchoolCFYRevenueStatusExplained,

                SchoolNFYCapitalForward = stagingApplyingSchool.SchoolNFYCapitalForward,
                SchoolNFYCapitalForwardStatusExplained = stagingApplyingSchool.SchoolNFYCapitalForwardStatusExplained,
                SchoolNFYCapitalIsDeficit = stagingApplyingSchool.SchoolNFYCapitalSurplusOrDeficit.ConvertSurplusOrDeficit(),
                SchoolNFYEndDate = stagingApplyingSchool.SchoolNFYEndDate,
                SchoolNFYRevenue = stagingApplyingSchool.SchoolNFYRevenue,
                SchoolNFYRevenueIsDeficit = stagingApplyingSchool.SchoolNFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
                SchoolNFYRevenueStatusExplained = stagingApplyingSchool.SchoolNFYRevenueStatusExplained,
                
                SchoolPartOfFederation = stagingApplyingSchool.SchoolPartOfFederation.ConvertDynamicsIntBool(),
                SchoolSACREExemption = stagingApplyingSchool.SchoolSACREExemption.ConvertDynamicsIntBool(),
                SchoolSACREExemptionEndDate = stagingApplyingSchool.SchoolSACREExemptionEndDate,
                SchoolSupportedFoundation = stagingApplyingSchool.SchoolSupportedFoundation.ConvertDynamicsIntBool(),
                SchoolSupportedFoundationBodyName = stagingApplyingSchool.SchoolSupportedFoundationBodyName,
                SchoolSupportGrantFundsPaidTo = stagingApplyingSchool.SchoolSupportGrantFundsPaidTo.ConvertFundsPaidTo(),

                SchoolLeases = new List<A2BSchoolLease>(),
                SchoolLoans = new List<A2BSchoolLoan>()
            }
        };

        ApplyingSchoolMapper mapper = new(_mockSchoolLease.Object, _mockSchoolLoan.Object);
        var result = mapper.Map(applyingSchool);

        result.Should().BeEquivalentTo(expectedResult);
    }
}