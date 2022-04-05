using System.Collections.Generic;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;

namespace ProcessApplicationFormFunction.Mappers;

public class ApplicationMapper : IMapper<StagingApplication, A2BApplication>
{
    private readonly IMapper<StagingKeyPerson, A2BApplicationKeyPerson> _keyPersonMapper;
    private readonly IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool> _applyingSchoolMapper;

    public ApplicationMapper(
        IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool> applyingSchoolMapper, 
        IMapper<StagingKeyPerson, A2BApplicationKeyPerson> keyPersonMapper)
    {
        _applyingSchoolMapper = applyingSchoolMapper;
        _keyPersonMapper = keyPersonMapper;
    }
    public IEnumerable<A2BApplication> Map(ICollection<StagingApplication> source)
    {
        return source.Select(application => new A2BApplication
        {
            ApplyingSchools = _applyingSchoolMapper.Map(application.ApplyingSchools).ToList(),
            KeyPersons = _keyPersonMapper.Map(application.KeyPersons).ToList(),
        });
    }
    
}