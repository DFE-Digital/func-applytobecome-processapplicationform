using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Extensions;

namespace ProcessApplicationFormFunction.Mappers;

public class ProjectMapper : IMapper<A2BApplication, AcademyConversionProject>
{
    private const decimal DefaultConversionSupportGrantAmount = 25000;
    private const string DefaultAcademyTypeAndRoute = "Converter";
    
    public IEnumerable<AcademyConversionProject> Map([NotNull] IEnumerable<A2BApplication> source)
    {
        List<AcademyConversionProject> projects = new();

        foreach (var application in source)
        {
            if(!application.ApplyingSchools.Any())
            {
                throw new ApplicationException("Application must have at least one school");
            }
           
            var school = application.ApplyingSchools.First();
            
            var project = new AcademyConversionProject
            {
                IfdPipelineId = 0, // not required
                Urn = school.Urn,
                SchoolName = school.Name,
                LocalAuthority = school.LocalAuthorityName,
                ApplicationReferenceNumber = application.ApplicationId,
                ProjectStatus = "Converter Pre-AO (C)",
                ApplicationReceivedDate = DateTime.Today,
                OpeningDate = DateTime.Today.AddMonths(6), // Business rule is to set this date to six months from project initiation
                TrustReferenceNumber = application.TrustId,
                NameOfTrust = application.TrustName,
                AcademyTypeAndRoute = DefaultAcademyTypeAndRoute,
                ProposedAcademyOpeningDate = school.SchoolConversionTargetDateDate,
                ConversionSupportGrantAmount = DefaultConversionSupportGrantAmount,
                PublishedAdmissionNumber = school.SchoolCapacityPublishedAdmissionsNumber.ToString(),
                PartOfPfiScheme = school.SchoolBuildLandPFIScheme.ToYesNoString(),
                FinancialDeficit = school.SchoolCFYCapitalIsDeficit.ToYesNoString(),
                RationaleForTrust = school.SchoolConversionReasonsForJoining,
                EqualitiesImpactAssessmentConsidered = school.SchoolAdEqualitiesImpactAssessment.ToYesNoString(),
                SponsorName = application.SponsorName,
                SponsorReferenceNumber = application.SponsorReferenceNumber,                
                RevenueCarryForwardAtEndMarchCurrentYear = ConvertDeficitAmountToNegativeValue(school.SchoolCFYRevenue, school.SchoolCFYRevenueIsDeficit),
                ProjectedRevenueBalanceAtEndMarchNextYear = ConvertDeficitAmountToNegativeValue(school.SchoolNFYRevenue, school.SchoolNFYRevenueIsDeficit),
                CapitalCarryForwardAtEndMarchCurrentYear = ConvertDeficitAmountToNegativeValue(school.SchoolCFYCapitalForward, school.SchoolCFYCapitalIsDeficit),
                CapitalCarryForwardAtEndMarchNextYear = ConvertDeficitAmountToNegativeValue(school.SchoolNFYCapitalForward, school.SchoolNFYCapitalIsDeficit),                
                YearOneProjectedPupilNumbers = school.ProjectedPupilNumbersYear1,
                YearTwoProjectedPupilNumbers = school.ProjectedPupilNumbersYear2,
                YearThreeProjectedPupilNumbers = school.ProjectedPupilNumbersYear3
            };
            
            projects.Add(project);
        }
        
        return projects;
    }

    private decimal? ConvertDeficitAmountToNegativeValue(decimal? amount, bool? isDeficit)
    {
        return isDeficit.HasValue ? isDeficit.Value ? amount * -1.0M : amount : null;
    }
}