using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessApplicationFormFunction.Database.Models
{
   [Table("A2BApplicationApplyingSchool", Schema = "sdd")]
   public record A2BApplicationApplyingSchool
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int ApplyingSchoolId { get; set; }

      public string SchoolDeclarationSignedById { get; set; }
      public string SchoolDeclarationSignedByName { get; set; }
      public bool? SchoolDeclarationBodyAgree { get; set; } // the information is true to the best of my knowledge
      public bool? SchoolDeclarationTeacherChair { get; set; } // I declare I am the teacher or chair of governors
      public string SchoolDeclarationSignedByEmail { get; set; }
      public string Name { get; set; }
      public string SchoolConversionReasonsForJoining { get; set; }
      public bool? SchoolConversionTargetDateDifferent { get; set; }
      public DateTime? SchoolConversionTargetDateDate { get; set; }
      public string SchoolConversionTargetDateExplained { get; set; }
      public bool? SchoolConversionChangeName { get; set; }
      public string SchoolConversionChangeNameValue { get; set; }
      public string SchoolConversionContactHeadName { get; set; }
      public string SchoolConversionContactHeadEmail { get; set; }
      public string SchoolConversionContactHeadTel { get; set; }
      public string SchoolConversionContactChairName { get; set; }
      public string SchoolConversionContactChairEmail { get; set; }
      public string SchoolConversionContactChairTel { get; set; }
      public string SchoolConversionContactRole { get; set; }
      public string SchoolConversionMainContactOtherName { get; set; }
      public string SchoolConversionMainContactOtherEmail { get; set; }
      public string SchoolConversionMainContactOtherTelephone { get; set; }
      public string SchoolConversionMainContactOtherRole { get; set; }
      public string SchoolConversionApproverContactName { get; set; }
      public string SchoolConversionApproverContactEmail { get; set; }
      public bool? SchoolAdInspectedButReportNotPublished { get; set; }
      public string SchoolAdInspectedReportNotPublishedExplain { get; set; }
      public bool? SchoolLaReorganization { get; set; }
      public string SchoolLaReorganizationExplain { get; set; }
      public bool? SchoolLaClosurePlans { get; set; }
      public string SchoolLaClosurePlansExplain { get; set; }
      public bool? SchoolPartOfFederation { get; set; }
      public bool? SchoolAddFurtherInformation { get; set; }
      public string SchoolFurtherInformation { get; set; }
      public string SchoolAdSchoolContributionToTrust { get; set; }
      public bool? SchoolAdSafeguarding { get; set; }
      public string SchoolAdSafeguardingExplained { get; set; }
      public bool? SchoolSACREExemption { get; set; }
      public DateTime? SchoolSACREExemptionEndDate { get; set; }
      public bool? SchoolFaithSchool { get; set; }
      public string SchoolFaithSchoolDioceseName { get; set; }
      public bool? SchoolSupportedFoundation { get; set; }
      public string SchoolSupportedFoundationBodyName { get; set; }
      public string SchoolAdFeederSchools { get; set; }
      public bool? SchoolAdEqualitiesImpactAssessment { get; set; }
      public string SchoolAdEqualitiesImpactAssessmentDetails { get; set; }

      [Column(TypeName = "decimal(18,2)")]
      public decimal? SchoolPFYRevenue { get; set; }
      public bool? SchoolPFYRevenueIsDeficit { get; set; }
      public string SchoolPFYRevenueStatusExplained { get; set; }

      [Column(TypeName = "decimal(18,2)")]
      public decimal? SchoolPFYCapitalForward { get; set; }
      public bool? SchoolPFYCapitalIsDeficit { get; set; }
      public string SchoolPFYCapitalForwardStatusExplained { get; set; }
      public DateTime? SchoolPFYEndDate { get; set; }

      [Column(TypeName = "decimal(18,2)")]
      public decimal? SchoolCFYRevenue { get; set; }
      public bool? SchoolCFYRevenueIsDeficit { get; set; }
      public string SchoolCFYRevenueStatusExplained { get; set; }

      [Column(TypeName = "decimal(18,2)")]
      public decimal? SchoolCFYCapitalForward { get; set; }
      public bool? SchoolCFYCapitalIsDeficit { get; set; }
      public string SchoolCFYCapitalForwardStatusExplained { get; set; }
      public DateTime? SchoolCFYEndDate { get; set; }

      [Column(TypeName = "decimal(18,2)")]
      public decimal? SchoolNFYRevenue { get; set; }
      public bool? SchoolNFYRevenueIsDeficit { get; set; }
      public string SchoolNFYRevenueStatusExplained { get; set; }

      [Column(TypeName = "decimal(18,2)")]
      public decimal? SchoolNFYCapitalForward { get; set; }
      public bool? SchoolNFYCapitalIsDeficit { get; set; }
      public string SchoolNFYCapitalForwardStatusExplained { get; set; }
      public DateTime? SchoolNFYEndDate { get; set; }
      public bool? SchoolFinancialInvestigations { get; set; } // int?
      public string SchoolFinancialInvestigationsExplain { get; set; }
      public bool? SchoolFinancialInvestigationsTrustAware { get; set; }
      public int? ProjectedPupilNumbersYear1 { get; set; }
      public int? ProjectedPupilNumbersYear2 { get; set; }
      public int? ProjectedPupilNumbersYear3 { get; set; }
      public string SchoolCapacityAssumptions { get; set; }
      public int? SchoolCapacityPublishedAdmissionsNumber { get; set; }
      public string SchoolBuildLandOwnerExplained { get; set; }
      public bool? SchoolBuildLandSharedFacilities { get; set; }
      public string SchoolBuildLandSharedFacilitiesExplained { get; set; }
      public bool? SchoolBuildLandWorksPlanned { get; set; }
      public string SchoolBuildLandWorksPlannedExplained { get; set; }
      public DateTime? SchoolBuildLandWorksPlannedDate { get; set; }
      public bool? SchoolBuildLandGrants { get; set; }
      public string SchoolBuildLandGrantsBody { get; set; }
      public bool? SchoolBuildLandPriorityBuildingProgramme { get; set; }
      public bool? SchoolBuildLandFutureProgramme { get; set; }
      public bool? SchoolBuildLandPFIScheme { get; set; }
      public string SchoolBuildLandPFISchemeType { get; set; }
      public bool? SchoolConsultationStakeholders { get; set; }
      public string SchoolConsultationStakeholdersConsult { get; set; }
      public string SchoolSupportGrantFundsPaidTo { get; set; }

      public string DiocesePermissionEvidenceDocumentLink { get; set; }
      public string FoundationEvidenceDocumentLink { get; set; }
      public string GoverningBodyConsentEvidenceDocumentLink { get; set; }

      [ForeignKey(nameof(ApplyingSchoolId))]
      public virtual ICollection<A2BSchoolLease> SchoolLeases { get; set; }

      [ForeignKey(nameof(ApplyingSchoolId))]
      public virtual ICollection<A2BSchoolLoan> SchoolLoans { get; set; }

      public string ApplicationId { get; set; }
      public virtual A2BApplication A2BApplication { get; set; }

      public int Urn { get; set; }

      public string LocalAuthorityName { get; set; }

      public Guid DynamicsApplyingSchoolId { get; set; }

      public Guid DynamicsApplicationId { get; set; }
   }
}