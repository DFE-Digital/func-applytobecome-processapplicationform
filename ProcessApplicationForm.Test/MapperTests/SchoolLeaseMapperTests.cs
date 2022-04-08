using System.Collections.Generic;
using FluentAssertions;
using ProcessApplicationForm.Test.Data;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class SchoolLeaseMapperTests
{
    private readonly SchoolLeaseMapper _mapper;
    public SchoolLeaseMapperTests() => _mapper = new();

    [Fact]
    public void Map_WhenGivenCollectionOfStagingSchoolLease_ShouldReturnCollectionOfTypeIEnumerableA2BSchoolLease()
    {
        List<StagingSchoolLease> stagingSchoolLeases = new() {TestData.StagingSchoolLeaseData};

        var result = _mapper.Map(stagingSchoolLeases);

        result.Should().BeAssignableTo<IEnumerable<A2BSchoolLease>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingSchoolLease_ShouldReturnMappedCollectionOfA2BSchoolLease()
    {
        List<StagingSchoolLease> stagingSchoolLeases = new() {TestData.StagingSchoolLeaseData};
        List<A2BSchoolLease> expected = new() {TestData.A2BSchoolLeaseData};
        
        var result = _mapper.Map(stagingSchoolLeases);

        result.Should().BeEquivalentTo(expected);
    }
}