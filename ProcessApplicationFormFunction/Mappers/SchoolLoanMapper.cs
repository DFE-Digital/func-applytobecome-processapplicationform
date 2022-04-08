using System.Collections.Generic;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;

namespace ProcessApplicationFormFunction.Mappers;

public class SchoolLoanMapper : IMapper<StagingSchoolLoan, A2BSchoolLoan>
{
    public IEnumerable<A2BSchoolLoan> Map(IEnumerable<StagingSchoolLoan> source) => source
        .Select(schoolLoan => new A2BSchoolLoan
        {
            SchoolLoanAmount = schoolLoan.SchoolLoanAmount,
            SchoolLoanInterestRate = schoolLoan.SchoolLoanInterestRate,
            SchoolLoanProvider = schoolLoan.SchoolLoanProvider,
            SchoolLoanPurpose = schoolLoan.SchoolLoanPurpose,
            SchoolLoanSchedule = schoolLoan.SchoolLoanSchedule
        });
}