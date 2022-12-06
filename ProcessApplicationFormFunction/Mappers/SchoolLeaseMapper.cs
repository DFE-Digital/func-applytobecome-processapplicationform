using System.Collections.Generic;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;

namespace ProcessApplicationFormFunction.Mappers;

public class SchoolLeaseMapper : IMapper<StagingSchoolLease, A2BSchoolLease>
{
    public IEnumerable<A2BSchoolLease> Map(IEnumerable<StagingSchoolLease> source) => source
        .Select(schoolLease => new A2BSchoolLease
        {
            SchoolLeaseInterestRate = schoolLease.SchoolLeaseInterestRate,
            SchoolLeasePaymentToDate = schoolLease.SchoolLeasePaymentToDate,
            SchoolLeasePurpose = schoolLease.SchoolLeasePurpose,
            SchoolLeaseRepaymentValue = schoolLease.SchoolLeaseRepaymentValue,
            SchoolLeaseResponsibleForAssets = schoolLease.SchoolLeaseResponsibleForAssets,
            SchoolLeaseTerm = schoolLease.SchoolLeaseTerm,
            SchoolLeaseValueOfAssets = schoolLease.SchoolLeaseValueOfAssets,
            DynamicsSchoolLeaseId = schoolLease.DynamicsSchoolLeaseId
        });
}