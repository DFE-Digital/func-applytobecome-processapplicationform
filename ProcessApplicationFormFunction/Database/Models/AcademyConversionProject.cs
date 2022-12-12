using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessApplicationFormFunction.Database.Models
{
   [Table("AcademyConversionProject", Schema = "sdd")]
   public record AcademyConversionProject
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      public int IfdPipelineId { get; set; }
      public int? Urn { get; set; }
      public string SchoolName { get; set; }
      public string LocalAuthority { get; set; }
      public string ApplicationReferenceNumber { get; set; }
      public string ProjectStatus { get; set; }
      public DateTime? ApplicationReceivedDate { get; set; }
      public DateTime? OpeningDate { get; set; }
      public string TrustReferenceNumber { get; set; }
      public string NameOfTrust { get; set; }
      public string SponsorReferenceNumber { get; set; }
      public string SponsorName { get; set; }
      public string AcademyTypeAndRoute { get; set; }
      public DateTime? ProposedAcademyOpeningDate { get; set; }

      [Column(TypeName = "decimal(38, 2)")]
      public decimal ConversionSupportGrantAmount { get; set; }
      public string PublishedAdmissionNumber { get; set; }
      public string PartOfPfiScheme { get; set; }
      public string FinancialDeficit { get; set; }
      public string RationaleForTrust { get; set; }
      public string EqualitiesImpactAssessmentConsidered { get; set; }

      // school budget info
      public DateTime? EndOfCurrentFinancialYear { get; set; }
      public DateTime? EndOfNextFinancialYear { get; set; }
      [Column(TypeName = "decimal(38, 2)")] public decimal? RevenueCarryForwardAtEndMarchCurrentYear { get; set; }
      [Column(TypeName = "decimal(38, 2)")] public decimal? ProjectedRevenueBalanceAtEndMarchNextYear { get; set; }
      [Column(TypeName = "decimal(38, 2)")] public decimal? CapitalCarryForwardAtEndMarchCurrentYear { get; set; }
      [Column(TypeName = "decimal(38, 2)")] public decimal? CapitalCarryForwardAtEndMarchNextYear { get; set; }
      public int? YearOneProjectedPupilNumbers { get; set; }
      public int? YearTwoProjectedPupilNumbers { get; set; }
      public int? YearThreeProjectedPupilNumbers { get; set; }
   }
}