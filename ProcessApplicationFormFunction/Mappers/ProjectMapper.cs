using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mime;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Extensions;

namespace ProcessApplicationFormFunction.Mappers;

// we would create the projects with the following settings:
//
//&& ifd.GeneralDetailsRouteOfProject == "Converter"
// && ifd.GeneralDetailsProjectStatus == "Converter Pre-AO (C)"
// && ifd.ApprovalProcessAppliedOrBrokered == "Applied"
// && ifd.ApprovalProcessApplicationDate --- from application form??
// && ifd.TrustSponsorManagementTrust != null  ----- there is a trust ref in application form??
// && ifd.DeliveryProcessApplicationFormReference != null -- this is the app form
// && ifd.GeneralDetailsProjectLead != null -- this is manually assigned and defines which projects a project
// can view.

public class ProjectMapper : IMapper<AcademyConversionProjectInformation, AcademyConversionProject>
{
    private const decimal DefaultConversionSupportGrantAmount = 25000;
    private const string DefaultAcademyTypeAndRoute = "Converter";
    
    public IEnumerable<AcademyConversionProject> Map([NotNull] IEnumerable<AcademyConversionProjectInformation> source)
    {
        List<AcademyConversionProject> projects = new();

        foreach (var data in source)
        {
            A2BApplicationApplyingSchool school;
            Establishment establishment;
            try
            {
                school = data.Application.ApplyingSchools.First();
                establishment = data.Establishments.First(e => e.Urn == school.Urn);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Application must have at least one school and associated establishment", e);
            }
            
            var project = new AcademyConversionProject
            {
                IfdPipelineId = 0, // not required
                Urn = school.Urn,
                SchoolName = school.Name,
                LocalAuthority = establishment.LaName,
                ApplicationReferenceNumber = data.Application.ApplicationId,
                ProjectStatus = "Converter Pre-AO (C)",
                ApplicationReceivedDate = DateTime.UtcNow,
                AssignedDate = null, // ** set when assigned to Project Lead **
                HeadTeacherBoardDate = null, // ??
                OpeningDate = DateTime.UtcNow.AddMonths(6),
                BaselineDate = null, // ??
                LocalAuthorityInformationTemplateSentDate = null, // ??
                LocalAuthorityInformationTemplateReturnedDate = null, // ??
                LocalAuthorityInformationTemplateComments = null, // ??
                LocalAuthorityInformationTemplateLink = null, // ??
                LocalAuthorityInformationTemplateSectionComplete = null, // ??
                RecommendationForProject = null, // ??
                Author = null, // ** This is set by Abby G after receiving email from team leader ** // 
                Version = null,  // ??
                ClearedBy = null,  // ** This is set by Abby G from a word document this is General Details Team Leader in KIM **
                AcademyOrderRequired = null,  // ??
                PreviousHeadTeacherBoardDate = null,  // ??
                PreviousHeadTeacherBoardDateQuestion = null,  // ??
                PreviousHeadTeacherBoardLink = null,  // ??
                TrustReferenceNumber = data.Application.TrustId,
                NameOfTrust = data.Application.TrustName,
                SponsorReferenceNumber = null, // ??
                SponsorName = null,  // ??
                AcademyTypeAndRoute = DefaultAcademyTypeAndRoute,
                ProposedAcademyOpeningDate = null,  // ??
                SchoolAndTrustInformationSectionComplete = null,
                ConversionSupportGrantAmount = DefaultConversionSupportGrantAmount,
                ConversionSupportGrantChangeReason = null, // ??
                SchoolPhase = establishment.PhaseOfEducationName,
                AgeRange = $"{establishment.StatutoryLowAge}-{establishment.StatutoryHighAge}",
                SchoolType = establishment.TypeOfEstablishmentName,
                ActualPupilNumbers = establishment.NumberOfPupils.ToIntOrNull(),
                Capacity = establishment.SchoolCapacity.ToIntOrNull(),
                PublishedAdmissionNumber = school.SchoolCapacityPublishedAdmissionsNumber.ToString(),
                PercentageFreeSchoolMeals = establishment.PercentageFsm.ToDecimalOrNull(),
                PartOfPfiScheme = school.SchoolBuildLandPFIScheme.ToYesNoString(),
                ViabilityIssues = null, // ??
                FinancialDeficit = null, // ??
                DiocesanTrust = establishment.DioceseName, // review this
                PercentageOfGoodOrOutstandingSchoolsInTheDiocesanTrust = null, // ??
                DistanceFromSchoolToTrustHeadquarters = null,
                DistanceFromSchoolToTrustHeadquartersAdditionalInformation = null,
                MemberOfParliamentParty = null,
                MemberOfParliamentName = null, 
                GeneralInformationSectionComplete = null,
                SchoolPerformanceAdditionalInformation = null,
                RationaleForProject = null, // ??
                RationaleForTrust = school.SchoolConversionReasonsForJoining,
                RationaleSectionComplete = null,
                RisksAndIssues = null,
                EqualitiesImpactAssessmentConsidered = school.SchoolAdEqualitiesImpactAssessment.ToYesNoString(),
                RisksAndIssuesSectionComplete = null,
                SchoolBudgetInformationAdditionalInformation = null,
                SchoolBudgetInformationSectionComplete = null,
                KeyStage2PerformanceAdditionalInformation = null,
                KeyStage4PerformanceAdditionalInformation = null,
                KeyStage5PerformanceAdditionalInformation = null,

                RevenueCarryForwardAtEndMarchCurrentYear = school.SchoolCFYRevenue,
                ProjectedRevenueBalanceAtEndMarchNextYear = school.SchoolNFYRevenue,
                CapitalCarryForwardAtEndMarchCurrentYear = school.SchoolCFYCapitalForward,
                CapitalCarryForwardAtEndMarchNextYear = school.SchoolNFYCapitalForward,

                YearOneProjectedCapacity = null,
                YearOneProjectedPupilNumbers = school.ProjectedPupilNumbersYear1,
                YearTwoProjectedCapacity = null,
                YearTwoProjectedPupilNumbers = school.ProjectedPupilNumbersYear2,
                YearThreeProjectedCapacity = null,
                YearThreeProjectedPupilNumbers = school.ProjectedPupilNumbersYear3
            };
            
            projects.Add(project);
        }
        
        return projects;
    }
}