using System.Collections.Generic;
using FluentAssertions;
using ProcessApplicationForm.Test.Data;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class KeyPersonMapperTests
{
    private readonly KeyPersonMapper _mapper;
    public KeyPersonMapperTests() => _mapper = new();

    [Fact]
    public void Map_WhenGivenCollectionOfStagingKeyPerson_ShouldReturnCollectionOfTypeA2BApplicationKeyPerson()
    {
        List<StagingKeyPerson> stagingKeyPersons = new() {TestData.StagingKeyPersonData};

        var result = _mapper.Map(stagingKeyPersons);

        result.Should().BeAssignableTo<IEnumerable<A2BApplicationKeyPerson>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingKeyPerson_ShouldReturnMappedCollectionOfA2BApplicationKeyPerson()
    {
        List<StagingKeyPerson> stagingKeyPersons = new() {TestData.StagingKeyPersonData};
        List<A2BApplicationKeyPerson> expected = new() {TestData.A2BApplicationKeyPersonData};

        var result = _mapper.Map(stagingKeyPersons);

        result.Should().BeEquivalentTo(expected);
    }
}