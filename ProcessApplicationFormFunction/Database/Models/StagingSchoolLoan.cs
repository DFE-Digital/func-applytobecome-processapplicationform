using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessApplicationFormFunction.Database.Models;

[Table("stg_schoolloan", Schema = "a2b")]
public record StagingSchoolLoan
{
    [Key]
    public Guid DynamicsSchoolLoanId {get;set;}
    public Guid DynamicsApplyingSchoolId {get;set;}
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal SchoolLoanAmount {get;set;}
    
    public string SchoolLoanPurpose { get; set; }
    public string SchoolLoanProvider {get;set;}
    public string SchoolLoanInterestRate {get;set;}
    public string SchoolLoanSchedule {get;set;}
}