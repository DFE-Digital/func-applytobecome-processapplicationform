using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class KeyPersonMapperTests
{
    [Fact]
    public void Map_WhenGivenCollectionOfStagingKeyPerson_ShouldReturnCollectionOfTypeA2BApplicationKeyPerson()
    {
        KeyPersonMapper mapper = new();
        List<StagingKeyPerson> source = new();

        var result = mapper.Map(source);

        Assert.IsAssignableFrom<IEnumerable<A2BApplicationKeyPerson>>(result);
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingKeyPerson_ShouldReturnMappedCollectionOfA2BApplicationKeyPerson()
    {
        Fixture fixture = new();
        var stagingSchoolKeyPerson = fixture.Create<StagingKeyPerson>();
        List<StagingKeyPerson> keyPerson = new() { stagingSchoolKeyPerson };
        List<A2BApplicationKeyPerson> expectedResult = new()
        {
            new()
            {
                Name = stagingSchoolKeyPerson.Name,
                KeyPersonBiography = stagingSchoolKeyPerson.KeyPersonBiography,
                KeyPersonCeoExecutive = stagingSchoolKeyPerson.KeyPersonCeoExecutive,
                KeyPersonChairOfTrust = stagingSchoolKeyPerson.KeyPersonChairOfTrust,
                KeyPersonDateOfBirth = stagingSchoolKeyPerson.KeyPersonDateOfBirth,
                KeyPersonFinancialDirector = stagingSchoolKeyPerson.KeyPersonFinancialDirector,
                KeyPersonMember = stagingSchoolKeyPerson.KeyPersonMember,
                KeyPersonOther = stagingSchoolKeyPerson.KeyPersonOther,
                KeyPersonTrustee = stagingSchoolKeyPerson.KeyPersonTrustee
            }
        };

        KeyPersonMapper mapper = new();
        var result = mapper.Map(keyPerson);

        result.Should().BeEquivalentTo(expectedResult);
    }
}