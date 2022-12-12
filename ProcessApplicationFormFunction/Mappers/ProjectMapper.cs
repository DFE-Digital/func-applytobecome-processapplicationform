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
         if (!application.ApplyingSchools.Any())
         {
            throw new ApplicationException("Application must have at least one school");
         }

         var school = application.ApplyingSchools.First();

         var now = DateTime.Now;

         var project = new AcademyConversionProject
         {
            IfdPipelineId = 0, // not required
            Urn = school.Urn,
            SchoolName = school.Name,
            LocalAuthority = school.LocalAuthorityName,
            ApplicationReferenceNumber = application.ApplicationId,
            ProjectStatus = "Converter Pre-AO (C)",
            ApplicationReceivedDate = application.ApplicationSubmittedOn,
            OpeningDate = now.AddMonths(6), // Business rule is to set this date to six months from project initiation
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
            EndOfCurrentFinancialYear = school.SchoolCFYEndDate,
            EndOfNextFinancialYear = school.SchoolNFYEndDate,
            RevenueCarryForwardAtEndMarchCurrentYear = school.SchoolCFYRevenue.ConvertDeficitAmountToNegativeValue(school.SchoolCFYRevenueIsDeficit),
            ProjectedRevenueBalanceAtEndMarchNextYear = school.SchoolNFYRevenue.ConvertDeficitAmountToNegativeValue(school.SchoolNFYRevenueIsDeficit),
            CapitalCarryForwardAtEndMarchCurrentYear = school.SchoolCFYCapitalForward.ConvertDeficitAmountToNegativeValue(school.SchoolCFYCapitalIsDeficit),
            CapitalCarryForwardAtEndMarchNextYear = school.SchoolNFYCapitalForward.ConvertDeficitAmountToNegativeValue(school.SchoolNFYCapitalIsDeficit),
            YearOneProjectedPupilNumbers = school.ProjectedPupilNumbersYear1,
            YearTwoProjectedPupilNumbers = school.ProjectedPupilNumbersYear2,
            YearThreeProjectedPupilNumbers = school.ProjectedPupilNumbersYear3,
            LastModifiedOn = now,
            CreatedOn = now
         };

         projects.Add(project);
      }

      return projects;
   }
}