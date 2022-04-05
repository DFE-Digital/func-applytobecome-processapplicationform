using System.Collections.Generic;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;

namespace ProcessApplicationFormFunction.Mappers;

public class ApplyingSchoolMapper : IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool>
{
    private readonly IMapper<StagingSchoolLease, A2BSchoolLease> _schoolLeaseMapper;
    private readonly IMapper<StagingSchoolLoan, A2BSchoolLoan> _schoolLoanMapper;

    public ApplyingSchoolMapper(
        IMapper<StagingSchoolLease, A2BSchoolLease> schoolLeaseMapper, 
        IMapper<StagingSchoolLoan, A2BSchoolLoan> schoolLoanMapper)
    {
        _schoolLeaseMapper = schoolLeaseMapper;
        _schoolLoanMapper = schoolLoanMapper;
    }

    public IEnumerable<A2BApplicationApplyingSchool> Map(ICollection<StagingApplyingSchool> source)
    {
        return source.Select(applyingSchool => new A2BApplicationApplyingSchool
        {
            SchoolLeases = _schoolLeaseMapper.Map(applyingSchool.SchoolLeases).ToList(),
            SchoolLoans = _schoolLoanMapper.Map(applyingSchool.SchoolLoans).ToList()
        });
    }
}