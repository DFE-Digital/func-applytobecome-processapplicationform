using System.Collections.Generic;
using AutoFixture;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Extensions;

namespace ProcessApplicationForm.Test.Data;

public static class TestData
{
    public static StagingApplication StagingApplicationData { get; }
    public static StagingApplyingSchool StagingApplyingSchoolData { get; }
    public static StagingKeyPerson StagingKeyPersonData { get; }
    public static StagingSchoolLoan StagingSchoolLoanData { get; }
    public static StagingSchoolLease StagingSchoolLeaseData { get; }
    public static A2BApplication A2BApplicationData { get; }
    public static A2BApplicationApplyingSchool A2BApplicationApplyingSchoolData { get; }
    public static A2BApplicationKeyPerson A2BApplicationKeyPersonData { get; }
    public static A2BSchoolLoan A2BSchoolLoanData { get; }
    public static A2BSchoolLease A2BSchoolLeaseData { get; }
    
    public static StagingApplication CompleteStagingApplication { get; }
    
    public static A2BApplication CompleteA2BApplication { get; }
    
    static TestData()
    {
        var fixture = new Fixture();
        
        StagingApplicationData = fixture.Create<StagingApplication>() with
        {
            ApplicationRole = 907660002,
            ApplicationType = 100000001,
            ChangesToLaGovernance = 907660000,
            ChangesToTrust = 907660000,
            FormTrustGrowthPlansYesNo = 907660000,
            FormTrustReasonApprovalToConvertAsSat = 907660000
        };
        
        A2BApplicationData = new()
        {
            ApplicationLeadAuthorId = StagingApplicationData.ApplicationLeadAuthorId,
            ApplicationLeadAuthorName = StagingApplicationData.ApplicationLeadAuthorName,
            ApplicationLeadEmail = StagingApplicationData.ApplicationLeadEmail,
            ApplicationRole = StagingApplicationData.ApplicationRole.ConvertApplicationRole(),
            ApplicationRoleOtherDescription = StagingApplicationData.ApplicationRoleOtherDescription,
            ApplicationStatusId = StagingApplicationData.ApplicationStatusId,
            ApplicationSubmitted = StagingApplicationData.ApplicationSubmitted,
            ApplicationType = StagingApplicationData.ApplicationType.ConvertApplicationType(),
            ApplicationVersion = StagingApplicationData.ApplicationVersion.ToString(),
            ChangesToLaGovernance = StagingApplicationData.ChangesToLaGovernance.ConvertDynamicsIntBool(),
            ChangesToLaGovernanceExplained = StagingApplicationData.ChangesToLaGovernanceExplained,
            ChangesToTrust = StagingApplicationData.ChangesToTrust.ConvertDynamicsIntBool(),
            ChangesToTrustExplained = StagingApplicationData.ChangesToTrustExplained,
            FormTrustGrowthPlansYesNo = StagingApplicationData.FormTrustGrowthPlansYesNo.ConvertDynamicsIntBool(),
            FormTrustImprovementApprovedSponsor = StagingApplicationData.FormTrustImprovementApprovedSponsor,
            FormTrustImprovementStrategy = StagingApplicationData.FormTrustImprovementStrategy,
            FormTrustImprovementSupport = StagingApplicationData.FormTrustImprovementSupport,
            FormTrustOpeningDate = StagingApplicationData.FormTrustOpeningDate,
            FormTrustPlanForGrowth = StagingApplicationData.FormTrustPlanForGrowth,
            FormTrustPlansForNoGrowth = StagingApplicationData.FormTrustPlansForNoGrowth,
            FormTrustProposedNameOfTrust = StagingApplicationData.FormTrustProposedNameOfTrust,
            FormTrustReasonApprovalToConvertAsSat = StagingApplicationData.FormTrustReasonApprovalToConvertAsSat.ConvertDynamicsIntBool(),
            FormTrustReasonApprovedPerson = StagingApplicationData.FormTrustReasonApprovedPerson,
            FormTrustReasonForming = StagingApplicationData.FormTrustReasonForming,
            FormTrustReasonFreedom = StagingApplicationData.FormTrustReasonFreedom,
            FormTrustReasonGeoAreas = StagingApplicationData.FormTrustReasonGeoAreas,
            FormTrustReasonImproveTeaching = StagingApplicationData.FormTrustReasonImproveTeaching,
            FormTrustReasonVision = StagingApplicationData.FormTrustReasonVision,
            Name = StagingApplicationData.Name,
            TrustApproverEmail = StagingApplicationData.TrustApproverEmail,
            TrustApproverName = StagingApplicationData.TrustApproverName,
            TrustId = StagingApplicationData.TrustId,
            ApplyingSchools = new List<A2BApplicationApplyingSchool>(),
            KeyPersons = new List<A2BApplicationKeyPerson>()
        };
        
        StagingApplyingSchoolData = fixture.Create<StagingApplyingSchool>() with
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

        A2BApplicationApplyingSchoolData = new()
        {
            Name = StagingApplyingSchoolData.Name,
            SchoolAddFurtherInformation = StagingApplyingSchoolData.SchoolAddFurtherInformation.ConvertDynamicsIntBool(),
            SchoolAdEqualitiesImpactAssessment = StagingApplyingSchoolData.SchoolAdEqualitiesImpactAssessment.ConvertDynamicsIntBool(),
            SchoolAdEqualitiesImpactAssessmentDetails = StagingApplyingSchoolData.SchoolAdEqualitiesImpactAssessmentDetails,
            SchoolAdFeederSchools = StagingApplyingSchoolData.SchoolAdFeederSchools,
            SchoolAdInspectedButReportNotPublished = StagingApplyingSchoolData.SchoolAdInspectedButReportNotPublished.ConvertDynamicsIntBool(),
            SchoolAdInspectedReportNotPublishedExplain = StagingApplyingSchoolData.SchoolAdInspectedReportNotPublishedExplain,
            SchoolAdSafeguarding = StagingApplyingSchoolData.SchoolAdSafeguarding.ConvertDynamicsIntBool(),
            SchoolAdSafeguardingExplained = StagingApplyingSchoolData.SchoolAdSafeguardingExplained,
            SchoolAdSchoolContributionToTrust = StagingApplyingSchoolData.SchoolAdSchoolContributionToTrust,
            SchoolBuildLandFutureProgramme = StagingApplyingSchoolData.SchoolBuildLandFutureProgramme.ConvertDynamicsIntBool(),
            SchoolBuildLandGrants = StagingApplyingSchoolData.SchoolBuildLandGrants.ConvertDynamicsIntBool(),
            SchoolBuildLandGrantsBody = StagingApplyingSchoolData.SchoolBuildLandGrantsBody,
            SchoolBuildLandOwnerExplained = StagingApplyingSchoolData.SchoolBuildLandOwnerExplained,
            SchoolBuildLandPFIScheme = StagingApplyingSchoolData.SchoolBuildLandPFIScheme.ConvertDynamicsIntBool(),
            SchoolBuildLandPFISchemeType = StagingApplyingSchoolData.SchoolBuildLandPFISchemeType,
            SchoolBuildLandPriorityBuildingProgramme = StagingApplyingSchoolData.SchoolBuildLandPriorityBuildingProgramme.ConvertDynamicsIntBool(),
            SchoolBuildLandSharedFacilities = StagingApplyingSchoolData.SchoolBuildLandSharedFacilities.ConvertDynamicsIntBool(),
            SchoolBuildLandSharedFacilitiesExplained = StagingApplyingSchoolData.SchoolBuildLandSharedFacilitiesExplained,
            SchoolBuildLandWorksPlanned = StagingApplyingSchoolData.SchoolBuildLandWorksPlanned.ConvertDynamicsIntBool(),
            SchoolBuildLandWorksPlannedDate = StagingApplyingSchoolData.SchoolBuildLandWorksPlannedDate,
            SchoolBuildLandWorksPlannedExplained = StagingApplyingSchoolData.SchoolBuildLandWorksPlannedExplained,
            SchoolCapacityAssumptions = StagingApplyingSchoolData.SchoolCapacityAssumptions,
            SchoolCapacityPublishedAdmissionsNumber = StagingApplyingSchoolData.SchoolCapacityPublishedAdmissionsNumber.ToIntOrNull(),
            SchoolCapacityYear1 = StagingApplyingSchoolData.SchoolCapacityYear1,
            SchoolCapacityYear2 = StagingApplyingSchoolData.SchoolCapacityYear2,
            SchoolCapacityYear3 = StagingApplyingSchoolData.SchoolCapacityYear3,
            SchoolConsultationStakeholders = StagingApplyingSchoolData.SchoolConsultationStakeholders.ConvertDynamicsIntBool(),
            SchoolConsultationStakeholdersConsult = StagingApplyingSchoolData.SchoolConsultationStakeholdersConsult,
            SchoolConversionApproverContactEmail = StagingApplyingSchoolData.SchoolConversionApproverContactEmail,
            SchoolConversionApproverContactName = StagingApplyingSchoolData.SchoolConversionApproverContactName,
            SchoolConversionChangeName = StagingApplyingSchoolData.SchoolConversionChangeName.ConvertDynamicsIntBool(),
            SchoolConversionChangeNameValue = StagingApplyingSchoolData.SchoolConversionChangeNameValue,
            SchoolConversionContactChairEmail = StagingApplyingSchoolData.SchoolConversionContactChairEmail,
            SchoolConversionContactChairName = StagingApplyingSchoolData.SchoolConversionContactChairName,
            SchoolConversionContactChairTel = StagingApplyingSchoolData.SchoolConversionContactChairTel,
            SchoolConversionContactHeadEmail = StagingApplyingSchoolData.SchoolConversionContactChairEmail,
            SchoolConversionContactHeadName = StagingApplyingSchoolData.SchoolConversionContactHeadName,
            SchoolConversionContactHeadTel = StagingApplyingSchoolData.SchoolConversionContactChairTel,
            SchoolConversionContactRole = StagingApplyingSchoolData.SchoolConversionContactRole.ConvertApplicationRole(),
            SchoolConversionMainContactOtherRole = StagingApplyingSchoolData.SchoolConversionMainContactOtherRole,
            SchoolConversionMainContactOtherEmail = StagingApplyingSchoolData.SchoolConversionMainContactOtherEmail,
            SchoolConversionMainContactOtherName = StagingApplyingSchoolData.SchoolConversionMainContactOtherName,
            SchoolConversionMainContactOtherTelephone = StagingApplyingSchoolData.SchoolConversionMainContactOtherTelephone,
            SchoolConversionReasonsForJoining = StagingApplyingSchoolData.SchoolConversionReasonsForJoining,
            SchoolConversionTargetDateDifferent = StagingApplyingSchoolData.SchoolConversionTargetDateDifferent.ConvertDynamicsIntBool(),
            SchoolConversionTargetDateDate = StagingApplyingSchoolData.SchoolConversionTargetDateDate,
            SchoolConversionTargetDateExplained = StagingApplyingSchoolData.SchoolConversionTargetDateExplained,
            SchoolDeclarationBodyAgree = StagingApplyingSchoolData.SchoolDeclarationBodyAgree.ConvertDynamicsIntBool(),
            SchoolDeclarationSignedByEmail = StagingApplyingSchoolData.SchoolDeclarationSignedByEmail,
            SchoolDeclarationSignedById = StagingApplyingSchoolData.SchoolDeclarationSignedById,
            SchoolDeclarationSignedByName = StagingApplyingSchoolData.SchoolDeclarationSignedByName,
            SchoolDeclarationTeacherChair = StagingApplyingSchoolData.SchoolDeclarationTeacherChair.ConvertDynamicsIntBool(),
            SchoolFaithSchool = StagingApplyingSchoolData.SchoolFaithSchool.ConvertDynamicsIntBool(),
            SchoolFaithSchoolDioceseName = StagingApplyingSchoolData.SchoolFaithSchoolDioceseName,
            SchoolFinancialInvestigations = StagingApplyingSchoolData.SchoolFinancialInvestigations.ConvertDynamicsIntBool(),
            SchoolFinancialInvestigationsExplain = StagingApplyingSchoolData.SchoolFinancialInvestigationsExplain,
            SchoolFinancialInvestigationsTrustAware = StagingApplyingSchoolData.SchoolFinancialInvestigationsTrustAware.ConvertDynamicsIntBool(),
            SchoolFurtherInformation = StagingApplyingSchoolData.SchoolFurtherInformation,
            SchoolLaClosurePlans = StagingApplyingSchoolData.SchoolLaClosurePlans.ConvertDynamicsIntBool(),
            SchoolLaClosurePlansExplain = StagingApplyingSchoolData.SchoolLaClosurePlansExplain,
            SchoolLaReorganization = StagingApplyingSchoolData.SchoolLaReorganization.ConvertDynamicsIntBool(),
            SchoolLaReorganizationExplain = StagingApplyingSchoolData.SchoolLaReorganizationExplain,
            SchoolPFYCapitalForward = StagingApplyingSchoolData.SchoolPFYCapitalForward,
            SchoolPFYCapitalForwardStatusExplained = StagingApplyingSchoolData.SchoolPFYCapitalForwardStatusExplained,
            SchoolPFYCapitalIsDeficit = StagingApplyingSchoolData.SchoolPFYCapitalSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolPFYEndDate = StagingApplyingSchoolData.SchoolPFYEndDate,
            SchoolPFYRevenue = StagingApplyingSchoolData.SchoolPFYRevenue,
            SchoolPFYRevenueIsDeficit = StagingApplyingSchoolData.SchoolPFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolPFYRevenueStatusExplained = StagingApplyingSchoolData.SchoolPFYRevenueStatusExplained,
            SchoolCFYCapitalForward = StagingApplyingSchoolData.SchoolCFYCapitalForward,
            SchoolCFYCapitalForwardStatusExplained = StagingApplyingSchoolData.SchoolCFYCapitalForwardStatusExplained,
            SchoolCFYCapitalIsDeficit = StagingApplyingSchoolData.SchoolCFYCapitalSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolCFYEndDate = StagingApplyingSchoolData.SchoolCFYEndDate,
            SchoolCFYRevenue = StagingApplyingSchoolData.SchoolCFYRevenue,
            SchoolCFYRevenueIsDeficit = StagingApplyingSchoolData.SchoolCFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolCFYRevenueStatusExplained = StagingApplyingSchoolData.SchoolCFYRevenueStatusExplained,
            SchoolNFYCapitalForward = StagingApplyingSchoolData.SchoolNFYCapitalForward,
            SchoolNFYCapitalForwardStatusExplained = StagingApplyingSchoolData.SchoolNFYCapitalForwardStatusExplained,
            SchoolNFYCapitalIsDeficit = StagingApplyingSchoolData.SchoolNFYCapitalSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolNFYEndDate = StagingApplyingSchoolData.SchoolNFYEndDate,
            SchoolNFYRevenue = StagingApplyingSchoolData.SchoolNFYRevenue,
            SchoolNFYRevenueIsDeficit = StagingApplyingSchoolData.SchoolNFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolNFYRevenueStatusExplained = StagingApplyingSchoolData.SchoolNFYRevenueStatusExplained,
            SchoolPartOfFederation = StagingApplyingSchoolData.SchoolPartOfFederation.ConvertDynamicsIntBool(),
            SchoolSACREExemption = StagingApplyingSchoolData.SchoolSACREExemption.ConvertDynamicsIntBool(),
            SchoolSACREExemptionEndDate = StagingApplyingSchoolData.SchoolSACREExemptionEndDate,
            SchoolSupportedFoundation = StagingApplyingSchoolData.SchoolSupportedFoundation.ConvertDynamicsIntBool(),
            SchoolSupportedFoundationBodyName = StagingApplyingSchoolData.SchoolSupportedFoundationBodyName,
            SchoolSupportGrantFundsPaidTo = StagingApplyingSchoolData.SchoolSupportGrantFundsPaidTo.ConvertFundsPaidTo(),
            SchoolLeases = new List<A2BSchoolLease>(),
            SchoolLoans = new List<A2BSchoolLoan>()
        };
        
        StagingKeyPersonData = fixture.Create<StagingKeyPerson>();
        
        A2BApplicationKeyPersonData = new()
        {
            Name = StagingKeyPersonData.Name,
            KeyPersonBiography = StagingKeyPersonData.KeyPersonBiography,
            KeyPersonCeoExecutive = StagingKeyPersonData.KeyPersonCeoExecutive,
            KeyPersonChairOfTrust = StagingKeyPersonData.KeyPersonChairOfTrust,
            KeyPersonDateOfBirth = StagingKeyPersonData.KeyPersonDateOfBirth,
            KeyPersonFinancialDirector = StagingKeyPersonData.KeyPersonFinancialDirector,
            KeyPersonMember = StagingKeyPersonData.KeyPersonMember,
            KeyPersonOther = StagingKeyPersonData.KeyPersonOther,
            KeyPersonTrustee = StagingKeyPersonData.KeyPersonTrustee
        };
        
        StagingSchoolLeaseData = fixture.Create<StagingSchoolLease>();
        
        A2BSchoolLeaseData = new()
        {
            SchoolLeaseInterestRate = StagingSchoolLeaseData.SchoolLeaseInterestRate,
            SchoolLeasePaymentToDate = StagingSchoolLeaseData.SchoolLeasePaymentToDate,
            SchoolLeasePurpose = StagingSchoolLeaseData.SchoolLeasePurpose,
            SchoolLeaseRepaymentValue = StagingSchoolLeaseData.SchoolLeaseRepaymentValue,
            SchoolLeaseResponsibleForAssets = StagingSchoolLeaseData.SchoolLeaseResponsibleForAssets,
            SchoolLeaseTerm = StagingSchoolLeaseData.SchoolLeaseTerm,
            SchoolLeaseValueOfAssets = StagingSchoolLeaseData.SchoolLeaseValueOfAssets
        };
        
        StagingSchoolLoanData = fixture.Create<StagingSchoolLoan>();
        
        A2BSchoolLoanData = new()
        {
            SchoolLoanAmount = StagingSchoolLoanData.SchoolLoanAmount,
            SchoolLoanInterestRate = StagingSchoolLoanData.SchoolLoanInterestRate,
            SchoolLoanProvider = StagingSchoolLoanData.SchoolLoanProvider,
            SchoolLoanPurpose = StagingSchoolLoanData.SchoolLoanPurpose,
            SchoolLoanSchedule = StagingSchoolLoanData.SchoolLoanSchedule
        };
        
        CompleteStagingApplication = StagingApplicationData with
        {
            KeyPersons = new List<StagingKeyPerson> {StagingKeyPersonData},
            ApplyingSchools = new List<StagingApplyingSchool>
            {
                StagingApplyingSchoolData with
                {
                    SchoolLeases = new List<StagingSchoolLease> {StagingSchoolLeaseData},
                    SchoolLoans = new List<StagingSchoolLoan> {StagingSchoolLoanData}
                }
            }
        };
        
        CompleteA2BApplication = A2BApplicationData with
        {
            KeyPersons = new List<A2BApplicationKeyPerson> {A2BApplicationKeyPersonData},
            ApplyingSchools = new List<A2BApplicationApplyingSchool>
            {
                A2BApplicationApplyingSchoolData with
                {
                    SchoolLeases = new List<A2BSchoolLease> {A2BSchoolLeaseData},
                    SchoolLoans = new List<A2BSchoolLoan> {A2BSchoolLoanData}
                }
            }
        };
    }
}