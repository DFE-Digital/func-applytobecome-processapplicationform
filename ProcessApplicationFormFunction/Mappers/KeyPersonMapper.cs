using System.Collections.Generic;
using System.Linq;
using ProcessApplicationFormFunction.Database.Models;

namespace ProcessApplicationFormFunction.Mappers;

public class KeyPersonMapper : IMapper<StagingKeyPerson, A2BApplicationKeyPerson>
{
    public IEnumerable<A2BApplicationKeyPerson> Map(ICollection<StagingKeyPerson> source) => source
        .Select(keyPerson => new A2BApplicationKeyPerson()
        {
            Name = keyPerson.Name,
            KeyPersonTrustee = keyPerson.KeyPersonTrustee,
            KeyPersonOther = keyPerson.KeyPersonOther,
            KeyPersonMember = keyPerson.KeyPersonMember,
            KeyPersonFinancialDirector = keyPerson.KeyPersonFinancialDirector,
            KeyPersonDateOfBirth = keyPerson.KeyPersonDateOfBirth,
            KeyPersonChairOfTrust = keyPerson.KeyPersonChairOfTrust,
            KeyPersonBiography = keyPerson.KeyPersonBiography,
            KeyPersonCeoExecutive = keyPerson.KeyPersonCeoExecutive
        });
}