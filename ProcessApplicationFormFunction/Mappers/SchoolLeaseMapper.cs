using System.Collections.Generic;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;

namespace ProcessApplicationFormFunction.Mappers;

public class SchoolLeaseMapper : IMapper<StagingSchoolLease, A2BSchoolLease>
{
    public IEnumerable<A2BSchoolLease> Map(ICollection<StagingSchoolLease> source)
    {
        return source.Select(schoolLease => new A2BSchoolLease());
    }
}