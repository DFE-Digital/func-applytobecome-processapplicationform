using System.Collections.Generic;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;

namespace ProcessApplicationFormFunction.Mappers;

public class SchoolLoanMapper : IMapper<StagingSchoolLoan, A2BSchoolLoan>
{
    public IEnumerable<A2BSchoolLoan> Map(ICollection<StagingSchoolLoan> source)
    {
        return source.Select(schoolLoan => new A2BSchoolLoan());
    }
}