using System.Collections.Generic;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Extensions;

namespace ProcessApplicationFormFunction.Mappers;

public class ApplicationMapper : IMapper<StagingApplication, A2BApplication>
{
    private readonly IMapper<StagingKeyPerson, A2BApplicationKeyPerson> _keyPersonMapper;
    private readonly IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool> _applyingSchoolMapper;

    public ApplicationMapper(
        IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool> applyingSchoolMapper, 
        IMapper<StagingKeyPerson, A2BApplicationKeyPerson> keyPersonMapper)
    {
        _applyingSchoolMapper = applyingSchoolMapper;
        _keyPersonMapper = keyPersonMapper;
    }
    public IEnumerable<A2BApplication> Map(IEnumerable<StagingApplication> source)
    {
        return source.Select(stagingApplication => new A2BApplication
        {
            ApplicationId = stagingApplication.Name,
            ApplicationLeadAuthorId = stagingApplication.ApplicationLeadAuthorId,
            ApplicationLeadAuthorName = stagingApplication.ApplicationLeadAuthorName,
            ApplicationLeadEmail = stagingApplication.ApplicationLeadEmail,
            ApplicationRole = stagingApplication.ApplicationRole.ConvertApplicationRole(),
            ApplicationRoleOtherDescription = stagingApplication.ApplicationRoleOtherDescription,
            ApplicationStatusId = stagingApplication.ApplicationStatusId,
            ApplicationSubmitted = stagingApplication.ApplicationSubmitted,
            ApplicationType = stagingApplication.ApplicationType.ConvertApplicationType(),
            ApplicationVersion = stagingApplication.ApplicationVersion.ToString(),
            ChangesToLaGovernance = stagingApplication.ChangesToLaGovernance.ConvertDynamicsIntBool(),
            ChangesToLaGovernanceExplained = stagingApplication.ChangesToLaGovernanceExplained,
            ChangesToTrust = stagingApplication.ChangesToTrust.ConvertDynamicsIntBool(),
            ChangesToTrustExplained = stagingApplication.ChangesToTrustExplained,
            FormTrustGrowthPlansYesNo = stagingApplication.FormTrustGrowthPlansYesNo.ConvertDynamicsIntBool(),
            FormTrustImprovementApprovedSponsor = stagingApplication.FormTrustImprovementApprovedSponsor,
            FormTrustImprovementStrategy = stagingApplication.FormTrustImprovementStrategy,
            FormTrustImprovementSupport = stagingApplication.FormTrustImprovementSupport,
            FormTrustOpeningDate = stagingApplication.FormTrustOpeningDate,
            FormTrustPlanForGrowth = stagingApplication.FormTrustPlanForGrowth,
            FormTrustPlansForNoGrowth = stagingApplication.FormTrustPlansForNoGrowth,
            FormTrustProposedNameOfTrust = stagingApplication.FormTrustProposedNameOfTrust,
            FormTrustReasonApprovalToConvertAsSat = stagingApplication.FormTrustReasonApprovalToConvertAsSat.ConvertDynamicsIntBool(),
            FormTrustReasonApprovedPerson = stagingApplication.FormTrustReasonApprovedPerson,
            FormTrustReasonForming = stagingApplication.FormTrustReasonForming,
            FormTrustReasonFreedom = stagingApplication.FormTrustReasonFreedom,
            FormTrustReasonGeoAreas = stagingApplication.FormTrustReasonGeoAreas,
            FormTrustReasonImproveTeaching = stagingApplication.FormTrustReasonImproveTeaching,
            FormTrustReasonVision = stagingApplication.FormTrustReasonVision,
            Name = stagingApplication.Name,
            TrustApproverEmail = stagingApplication.TrustApproverEmail,
            TrustApproverName = stagingApplication.TrustApproverName,
            TrustId = stagingApplication.TrustId,
            TrustName = stagingApplication.TrustName,
            ApplicationSubmittedOn = stagingApplication.ApplicationSubmittedOn,
            ApplyingSchools = _applyingSchoolMapper.Map(stagingApplication.ApplyingSchools).ToHashSet(),
            KeyPersons = _keyPersonMapper.Map(stagingApplication.KeyPersons).ToHashSet()
        });
    }    
}