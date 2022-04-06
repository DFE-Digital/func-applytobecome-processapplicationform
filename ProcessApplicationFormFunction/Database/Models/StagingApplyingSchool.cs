using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessApplicationFormFunction.Database.Models;

[Table("stg_applyingschool", Schema = "a2b")]
public record StagingApplyingSchool
{
	[Key]
	public Guid DynamicsApplyingSchoolId {get;init;}
	
	public Guid DynamicsApplicationId {get;init;}
	
	public string SchoolDeclarationSignedById {get;init;}
	public int? SchoolDeclarationBodyAgree {get;init;}
	public int? SchoolDeclarationTeacherChair {get;init;}
	public string SchoolDeclarationSignedByEmail {get;init;}
	public string Name {get;init;}
	public string UpdatedSchoolFields {get;init;}
	public string SchoolConversionReasonsForJoining {get;init;}
	public int? SchoolConversionTargetDateDifferent {get;init;}
	public DateTime? SchoolConversionTargetDateDate {get;init;}
	public string SchoolConversionTargetDateExplained {get;init;}
	public int? SchoolConversionChangeName {get;init;}
	public string SchoolConversionChangeNameValue {get;init;}
	public string SchoolConversionContactHeadName {get;init;}
	public string SchoolConversionContactHeadEmail {get;init;}
	public string SchoolConversionContactHeadTel {get;init;}
    public string SchoolConversionContactChairName { get; init; }
    public string SchoolConversionContactChairEmail {get;init;}
	public string SchoolConversionContactChairTel {get;init;}
	public string SchoolConversionMainContactOtherName {get;init;}
	public string SchoolConversionMainContactOtherEmail {get;init;}
	public string SchoolConversionMainContactOtherTelephone {get;init;}
    public int? SchoolConversionMainContactOther { get; init; }
    public string SchoolConversionMainContactOtherRole {get;init;}
	public string SchoolConversionApproverContactName {get;init;}
	public string SchoolConversionApproverContactEmail {get;init;}
	public int? SchoolAdInspectedButReportNotPublished {get;init;}
	public string SchoolAdInspectedReportNotPublishedExplain {get;init;}
	public int? SchoolLaReorganization {get;init;}
	public string SchoolLaReorganizationExplain {get;init;}
	public int? SchoolLaClosurePlans {get;init;}
	public string SchoolLaClosurePlansExplain {get;init;}
	public int? SchoolPartOfFederation {get;init;}
	public int? SchoolAddFurtherInformation {get;init;}
	public string SchoolFurtherInformation {get;init;}
	public string SchoolAdSchoolContributionToTrust {get;init;}
	public int? SchoolAdSafeguarding {get;init;}
	public string SchoolAdSafeguardingExplained {get;init;}
	public int? SchoolSACREExemption {get;init;}
	public DateTime? SchoolSACREExemptionEndDate {get;init;}
	public int? SchoolFaithSchool {get;init;}
	public string SchoolFaithSchoolDioceseName {get;init;}
	public int? SchoolSupportedFoundation {get;init;}
	public string SchoolSupportedFoundationBodyName {get;init;}
	public string SchoolAdFeederSchools {get;init;}
	public int? SchoolAdEqualitiesImpactAssessment {get;init;}
	public string SchoolAdEqualitiesImpactAssessmentDetails { get; init; }
		
	[Column(TypeName = "decimal(18,2)")]
	public decimal SchoolPFYRevenue {get;init;}
    public int?  SchoolPFYRevenueSurplusOrDeficit{ get; init; }
    public string SchoolPFYRevenueStatusExplained {get;init;}
		
	[Column(TypeName = "decimal(18,2)")]
	public decimal SchoolPFYCapitalForward {get;init;}
    public int? SchoolPFYCapitalSurplusOrDeficit { get; set; }
    public string SchoolPFYCapitalForwardStatusExplained {get;init;}
		
	[Column(TypeName = "decimal(18,2)")]
	public decimal SchoolCFYRevenue {get;init;}
    public int? SchoolCFYRevenueSurplusOrDeficit { get; set; }
    public string SchoolCFYRevenueStatusExplained {get;init;}
		
	[Column(TypeName = "decimal(18,2)")]
	public decimal SchoolCFYCapitalForward {get;init;}
    public int? SchoolCFYCapitalSurplusOrDeficit { get; set; }
    public string SchoolCFYCapitalForwardStatusExplained {get;init;}
		
	[Column(TypeName = "decimal(18,2)")]
	public decimal SchoolNFYRevenue {get;init;}
    public int? SchoolNFYCapitalSurplusOrDeficit { get; set; }
    public string SchoolNFYRevenueStatusExplained {get;init;}
		
	[Column(TypeName = "decimal(18,2)")]
	public decimal SchoolNFYCapitalForward {get;init;}
    public int? SchoolNFYRevenueSurplusOrDeficit { get; set; }
    public string SchoolNFYCapitalForwardStatusExplained {get;init;}
	public int? SchoolFinancialInvestigations {get;init;}
	public string SchoolFinancialInvestigationsExplain {get;init;}
	public int? SchoolFinancialInvestigationsTrustAware {get;init;}
	public DateTime? SchoolNFYEndDate {get;init;}
	public DateTime? SchoolPFYEndDate {get;init;}
	public DateTime? SchoolCFYEndDate {get;init;}
	public int? SchoolLoanExists {get;init;}
	public int? SchoolLeaseExists {get;init;}
	public int? SchoolCapacityYear1 {get;init;}
	public int? SchoolCapacityYear2 {get;init;}
	public int? SchoolCapacityYear3 {get;init;}
	public string SchoolCapacityAssumptions {get;init;}
	public string SchoolCapacityPublishedAdmissionsNumber {get;init;}
	public string SchoolBuildLandOwnerExplained {get;init;}
	public int? SchoolBuildLandSharedFacilities {get;init;}
	public string SchoolBuildLandSharedFacilitiesExplained {get;init;}
	public int? SchoolBuildLandWorksPlanned {get;init;}
	public string SchoolBuildLandWorksPlannedExplained {get;init;}
	public DateTime? SchoolBuildLandWorksPlannedDate {get;init;}
	public int? SchoolBuildLandGrants {get;init;}
	public string SchoolBuildLandGrantsBody {get;init;}
	public int? SchoolBuildLandPriorityBuildingProgramme {get;init;}
	public int? SchoolBuildLandFutureProgramme {get;init;}
	public int? SchoolBuildLandPFIScheme {get;init;}
	public string SchoolBuildLandPFISchemeType {get;init;}
	public int? SchoolConsultationStakeholders {get;init;}
	public string SchoolConsultationStakeholdersConsult {get;init;}
	public int? SchoolSupportGrantFundsPaidTo {get;init;}
	public string SchoolDeclarationSignedByName {get;init;}
	
	public virtual ICollection<StagingSchoolLease> SchoolLeases { get; init; }
	public virtual ICollection<StagingSchoolLoan> SchoolLoans { get; init; }
}