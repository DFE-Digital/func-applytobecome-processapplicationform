using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class SchoolLeaseMapperTests
{
    [Fact]
    public void Map_WhenGivenCollectionOfStagingSchoolLease_ShouldReturnCollectionOfTypeIEnumerableA2BSchoolLease()
    {
        SchoolLeaseMapper mapper = new();
        List<StagingSchoolLease> source = new();

        var result = mapper.Map(source);

        result.Should().BeAssignableTo<IEnumerable<A2BSchoolLease>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingSchoolLease_ShouldReturnMappedCollectionOfA2BSchoolLease()
    {
        Fixture fixture = new Fixture();
        var stagingSchoolLease = fixture.Create<StagingSchoolLease>();
        List<StagingSchoolLease> schoolLease = new()  { stagingSchoolLease };
        List<A2BSchoolLease> expectedResult = new()
        {
            new()
            {
                SchoolLeaseInterestRate = stagingSchoolLease.SchoolLeaseInterestRate,
                SchoolLeasePaymentToDate = stagingSchoolLease.SchoolLeasePaymentToDate,
                SchoolLeasePurpose = stagingSchoolLease.SchoolLeasePurpose,
                SchoolLeaseRepaymentValue = stagingSchoolLease.SchoolLeaseRepaymentValue,
                SchoolLeaseResponsibleForAssets = stagingSchoolLease.SchoolLeaseResponsibleForAssets,
                SchoolLeaseTerm = stagingSchoolLease.SchoolLeaseTerm,
                SchoolLeaseValueOfAssets = stagingSchoolLease.SchoolLeaseValueOfAssets
            }
        };

        SchoolLeaseMapper mapper = new();
        var result = mapper.Map(schoolLease);

        result.Should().BeEquivalentTo(expectedResult);
    }
}