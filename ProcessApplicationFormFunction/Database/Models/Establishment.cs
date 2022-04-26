using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessApplicationFormFunction.Database.Models;

[Table("establishment", Schema = "gias")]
public record Establishment
{
    [Key]
    public int Urn { get; set; }
    public string LaCode { get; set; }
    public string LaName { get; set; }
    public string EstablishmentNumber { get; set; }
    public string EstablishmentName { get; set; }
    public string TypeOfEstablishmentCode { get; set; }
    public string TypeOfEstablishmentName { get; set; }
    public string EstablishmentTypeGroupCode { get; set; }
    public string EstablishmentTypeGroupName { get; set; }
    public string EstablishmentStatusCode { get; set; }
    public string EstablishmentStatusName { get; set; }
    public string ReasonEstablishmentOpenedCode { get; set; }
    public string ReasonEstablishmentOpenedName { get; set; }
    public string OpenDate { get; set; }
    public string ReasonEstablishmentClosedCode { get; set; }
    public string ReasonEstablishmentClosedName { get; set; }
    public string CloseDate { get; set; }
    public string PhaseOfEducationCode { get; set; }
    public string PhaseOfEducationName { get; set; }
    public string StatutoryLowAge { get; set; }
    public string StatutoryHighAge { get; set; }
    public string BoardersCode { get; set; }
    public string BoardersName { get; set; }
    public string NurseryProvisionName { get; set; }
    public string OfficialSixthFormCode { get; set; }
    public string OfficialSixthFormName { get; set; }
    public string GenderCode { get; set; }
    public string GenderName { get; set; }
    public string ReligiousCharacterCode { get; set; }
    public string ReligiousCharacterName { get; set; }
    public string ReligiousEthosName { get; set; }
    public string DioceseCode { get; set; }
    public string DioceseName { get; set; }
    public string AdmissionsPolicyCode { get; set; }
    public string AdmissionsPolicyName { get; set; }
    public string SchoolCapacity { get; set; }
    public string SpecialClassesCode { get; set; }
    public string SpecialClassesName { get; set; }
    public string CensusDate { get; set; }
    public string NumberOfPupils { get; set; }
    public string NumberOfBoys { get; set; }
    public string NumberOfGirls { get; set; }
    public string PercentageFsm { get; set; }
    public string TrustSchoolFlagCode { get; set; }
    public string TrustSchoolFlagName { get; set; }
    public string TrustsCode { get; set; }
    public string TrustsName { get; set; }
    public string SchoolSponsorFlagName { get; set; }
    public string SchoolSponsorsName { get; set; }
    public string FederationFlagName { get; set; }
    public string FederationsCode { get; set; }
    public string FederationsName { get; set; }
    public string Ukprn { get; set; }
    public string Feheidentifier { get; set; }
    public string FurtherEducationTypeName { get; set; }
    public string OfstedLastInsp { get; set; }
    public string OfstedSpecialMeasuresCode { get; set; }
    public string OfstedSpecialMeasuresName { get; set; }
    public string LastChangedDate { get; set; }
    public string Street { get; set; }
    public string Locality { get; set; }
    public string Address3 { get; set; }
    public string Town { get; set; }
    public string CountyName { get; set; }
    public string Postcode { get; set; }
    public string SchoolWebsite { get; set; }
    public string TelephoneNum { get; set; }
    public string HeadTitleName { get; set; }
    public string HeadFirstName { get; set; }
    public string HeadLastName { get; set; }
    public string HeadPreferredJobTitle { get; set; }
    public string InspectorateNameName { get; set; }
    public string InspectorateReport { get; set; }
    public string DateOfLastInspectionVisit { get; set; }
    public string NextInspectionVisit { get; set; }
    public string TeenMothName { get; set; }
    public string TeenMothPlaces { get; set; }
    public string CcfName { get; set; }
    public string SenpruName { get; set; }
    public string EbdName { get; set; }
    public string PlacesPru { get; set; }
    public string FtprovName { get; set; }
    public string EdByOtherName { get; set; }
    public string Section41ApprovedName { get; set; }
    public string Sen1Name { get; set; }
    public string Sen2Name { get; set; }
    public string Sen3Name { get; set; }
    public string Sen4Name { get; set; }
    public string Sen5Name { get; set; }
    public string Sen6Name { get; set; }
    public string Sen7Name { get; set; }
    public string Sen8Name { get; set; }
    public string Sen9Name { get; set; }
    public string Sen10Name { get; set; }
    public string Sen11Name { get; set; }
    public string Sen12Name { get; set; }
    public string Sen13Name { get; set; }
    public string TypeOfResourcedProvisionName { get; set; }
    public string ResourcedProvisionOnRoll { get; set; }
    public string ResourcedProvisionCapacity { get; set; }
    public string SenUnitOnRoll { get; set; }
    public string SenUnitCapacity { get; set; }
    public string GorCode { get; set; }
    public string GorName { get; set; }
    public string DistrictAdministrativeCode { get; set; }
    public string DistrictAdministrativeName { get; set; }
    public string AdministrativeWardCode { get; set; }
    public string AdministrativeWardName { get; set; }
    public string ParliamentaryConstituencyCode { get; set; }
    public string ParliamentaryConstituencyName { get; set; }
    public string UrbanRuralCode { get; set; }
    public string UrbanRuralName { get; set; }
    public string GsslacodeName { get; set; }
    public string Easting { get; set; }
    public string Northing { get; set; }
    public string MsoaName { get; set; }
    public string LsoaName { get; set; }
    public string Senstat { get; set; }
    public string SennoStat { get; set; }
    public string BoardingEstablishmentName { get; set; }
    public string PropsName { get; set; }
    public string PreviousLaCode { get; set; }
    public string PreviousLaName { get; set; }
    public string PreviousEstablishmentNumber { get; set; }
    public string OfstedRatingName { get; set; }
    public string RscregionName { get; set; }
    public string CountryName { get; set; }
    public string Uprn { get; set; }
    public string SiteName { get; set; }
    public string MsoaCode { get; set; }
    public string LsoaCode { get; set; }
    public string BsoinspectorateNameName { get; set; }
    public string Chnumber { get; set; }
    public string EstablishmentAccreditedCode { get; set; }
    public string EstablishmentAccreditedName { get; set; }
    public string QabnameCode { get; set; }
    public string QabnameName { get; set; }
    public string Qabreport { get; set; }
}