using System.Collections.Generic;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;

namespace ProcessApplicationFormFunction.Mappers;

public class KeyPersonMapper : IMapper<StagingKeyPerson, A2BApplicationKeyPerson>
{
    public IEnumerable<A2BApplicationKeyPerson> Map(ICollection<StagingKeyPerson> source)
    {
        return source.Select(keyPerson => new A2BApplicationKeyPerson());
    }
}