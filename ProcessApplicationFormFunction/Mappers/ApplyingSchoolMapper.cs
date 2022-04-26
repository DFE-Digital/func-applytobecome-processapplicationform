using System.Collections.Generic;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Extensions;

namespace ProcessApplicationFormFunction.Mappers;

public class ApplyingSchoolMapper : IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool>
{
    private readonly IMapper<StagingSchoolLease, A2BSchoolLease> _schoolLeaseMapper;
    private readonly IMapper<StagingSchoolLoan, A2BSchoolLoan> _schoolLoanMapper;

    public ApplyingSchoolMapper(
        IMapper<StagingSchoolLease, A2BSchoolLease> schoolLeaseMapper, 
        IMapper<StagingSchoolLoan, A2BSchoolLoan> schoolLoanMapper)
    {
        _schoolLeaseMapper = schoolLeaseMapper;
        _schoolLoanMapper = schoolLoanMapper;
    }

    public IEnumerable<A2BApplicationApplyingSchool> Map(IEnumerable<StagingApplyingSchool> source)
    {
        return source.Select(applyingSchool => new A2BApplicationApplyingSchool
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
            SchoolPFYCapitalIsDeficit = applyingSchool.SchoolPFYCapitalForwardSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolPFYEndDate = applyingSchool.SchoolPFYEndDate,
            SchoolPFYRevenue = applyingSchool.SchoolPFYRevenue,
            SchoolPFYRevenueIsDeficit = applyingSchool.SchoolPFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolPFYRevenueStatusExplained = applyingSchool.SchoolPFYRevenueStatusExplained,
            SchoolCFYCapitalForward = applyingSchool.SchoolCFYCapitalForward,
            SchoolCFYCapitalForwardStatusExplained = applyingSchool.SchoolCFYCapitalForwardStatusExplained,
            SchoolCFYCapitalIsDeficit = applyingSchool.SchoolCFYCapitalForwardSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolCFYEndDate = applyingSchool.SchoolCFYEndDate,
            SchoolCFYRevenue = applyingSchool.SchoolCFYRevenue,
            SchoolCFYRevenueIsDeficit = applyingSchool.SchoolCFYRevenueSurplusOrDeficit.ConvertSurplusOrDeficit(),
            SchoolCFYRevenueStatusExplained = applyingSchool.SchoolCFYRevenueStatusExplained,
            SchoolNFYCapitalForward = applyingSchool.SchoolNFYCapitalForward,
            SchoolNFYCapitalForwardStatusExplained = applyingSchool.SchoolNFYCapitalForwardStatusExplained,
            SchoolNFYCapitalIsDeficit = applyingSchool.SchoolNFYCapitalForwardSurplusOrDeficit.ConvertSurplusOrDeficit(),
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
            
            SchoolLeases = _schoolLeaseMapper.Map(applyingSchool.SchoolLeases).ToHashSet(),
            SchoolLoans = _schoolLoanMapper.Map(applyingSchool.SchoolLoans).ToHashSet(),
            
            Urn = applyingSchool.Urn
        });
    }
}