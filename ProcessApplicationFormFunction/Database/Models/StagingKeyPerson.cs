using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessApplicationFormFunction.Database.Models;

[Table("stg_keyperson", Schema = "a2b")]
public record StagingKeyPerson
{
    [Key]
    public Guid DynamicsKeyPersonId {get;set;}
    
    public Guid DynamicsApplicationId {get;set;}
    public string Name { get; set; }
    public DateTime? KeyPersonDateOfBirth {get;set;}
    public string KeyPersonBiography {get;set;}
    public bool? KeyPersonCeoExecutive {get;set;}
    public bool? KeyPersonChairOfTrust {get;set;}
    public bool? KeyPersonFinancialDirector {get;set;}
    public bool? KeyPersonMember {get;set;}
    public bool? KeyPersonOther {get;set;}
    public bool? KeyPersonTrustee {get;set;}
}