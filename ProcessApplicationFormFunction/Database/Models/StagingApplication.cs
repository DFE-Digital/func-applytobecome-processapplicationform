using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessApplicationFormFunction.Database.Models;

[Table("stg_application", Schema = "a2b")]
public record StagingApplication
{
    [Key]
    public Guid DynamicsApplicationId { get; init; }
    
    public string Name {get; init;}
    public string FormTrustProposedNameOfTrust {get; init;}
    public bool? ApplicationSubmitted {get; init;}
    public string ApplicationLeadAuthorId {get; init;}
    
    public int? ApplicationType { get; init; }
    public int? ApplicationVersion {get; init;}
    public string ApplicationLeadAuthorName {get; init;}
    public string ApplicationLeadEmail {get; init;}
    public int? ApplicationRole {get; init;}
    public string ApplicationRoleOtherDescription {get; init;}
    public int? ChangesToTrust {get; init;}
    public string ChangesToTrustExplained {get; init;}
    public int? ChangesToLaGovernance {get; init;}
    public string ChangesToLaGovernanceExplained {get; init;}
    public DateTime? FormTrustOpeningDate {get; init;}
    public string TrustApproverName {get; init;}
    public string TrustApproverEmail {get; init;}
    public int? FormTrustReasonApprovalToConvertAsSat {get; init;}
    public string FormTrustReasonApprovedPerson {get; init;}
    public string FormTrustReasonForming {get; init;}
    public string FormTrustReasonVision {get; init;}
    public string FormTrustReasonGeoAreas {get; init;}
    public string FormTrustReasonFreedom {get; init;}
    public string FormTrustReasonImproveTeaching {get; init;}
    public string FormTrustPlanForGrowth {get; init;}
    public string FormTrustPlansForNoGrowth {get; init;}
    public int? FormTrustGrowthPlansYesNo {get; init;}
    public string FormTrustImprovementSupport {get; init;}
    public string FormTrustImprovementStrategy {get; init;}
    public string FormTrustImprovementApprovedSponsor {get; init;}
    public string TrustId {get; init;}
    
    public string TrustName { get; init; }
    public string ApplicationStatusId {get; init;}
    public DateTime ApplicationSubmittedOn { get; init; }

    [ForeignKey(nameof(DynamicsApplicationId))]
    public virtual ICollection<StagingKeyPerson> KeyPersons { get; init; }
    
    [ForeignKey(nameof(DynamicsApplicationId))]
    public virtual ICollection<StagingApplyingSchool> ApplyingSchools { get; init; }
};