using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessApplicationFormFunction.Database.Models;

[Table("stg_schoollease", Schema = "a2b")]
public record StagingSchoolLease
{
    [Key]
    public Guid DynamicsSchoolLeaseId {get;set;}
    
    public Guid DynamicsApplyingSchoolId {get;set;}
    public string SchoolLeaseTerm {get;set;}
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal SchoolLeaseRepaymentValue {get;set;}
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal SchoolLeaseInterestRate {get;set;}
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal SchoolLeasePaymentToDate {get;set;}
    
    public string SchoolLeasePurpose {get;set;}
    public string SchoolLeaseValueOfAssets {get;set;}
    public string SchoolLeaseResponsibleForAssets {get;set;}
}