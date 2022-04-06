using System.Collections.Generic;
using FluentAssertions;
using ProcessApplicationForm.Test.Data;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class SchoolLoanMapperTests
{
    private readonly SchoolLoanMapper _mapper;

    public SchoolLoanMapperTests() => _mapper = new();

    [Fact]
    public void Map_WhenGivenCollectionOfStagingSchoolLoan_ShouldReturnCollectionOfTypeIEnumerableA2BSchoolLoan()
    {
        List<StagingSchoolLoan> stagingSchoolLoans = new() {TestData.StagingSchoolLoanData};

        var result = _mapper.Map(stagingSchoolLoans);

        result.Should().BeAssignableTo<IEnumerable<A2BSchoolLoan>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingSchoolLoan_ShouldReturnMappedCollectionOfA2BSchoolLoan()
    {
        List<StagingSchoolLoan> schoolLoanList = new() {TestData.StagingSchoolLoanData};
        List<A2BSchoolLoan> expected = new() {TestData.A2BSchoolLoanData};
        
        var result = _mapper.Map(schoolLoanList);
        
        result.Should().BeEquivalentTo(expected);
    }
}