using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class SchoolLoanMapperTests
{
    [Fact]
    public void Map_WhenGivenCollectionOfStagingSchoolLoan_ShouldReturnCollectionOfTypeIEnumerableA2BSchoolLoan()
    {
        SchoolLoanMapper mapper = new();
        List<StagingSchoolLoan> source = new();

        var result = mapper.Map(source);

        result.Should().BeAssignableTo<IEnumerable<A2BSchoolLoan>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingSchoolLoan_ShouldReturnMappedCollectionOfA2BSchoolLoan()
    {
        Fixture fixture = new();
        var stagingSchoolLoan = fixture.Create<StagingSchoolLoan>();
        List<StagingSchoolLoan> schoolLoanList = new() { stagingSchoolLoan };

        List<A2BSchoolLoan> expectedResult = new() {
            new() {
                SchoolLoanAmount = stagingSchoolLoan.SchoolLoanAmount,
                SchoolLoanInterestRate = stagingSchoolLoan.SchoolLoanInterestRate,
                SchoolLoanProvider = stagingSchoolLoan.SchoolLoanProvider,
                SchoolLoanPurpose = stagingSchoolLoan.SchoolLoanPurpose,
                SchoolLoanSchedule = stagingSchoolLoan.SchoolLoanSchedule
            }
        };

        SchoolLoanMapper mapper = new();
         
        var result = mapper.Map(schoolLoanList);
        result.Should().BeEquivalentTo(expectedResult);
    }
}