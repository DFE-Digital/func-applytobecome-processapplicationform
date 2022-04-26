using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using ProcessApplicationForm.Test.Data;
using ProcessApplicationFormFunction;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class ProjectMapperTests
{
    private readonly ProjectMapper _mapper;

    public ProjectMapperTests()
    {
        _mapper = new();
    }
    
    [Fact]
    public void Map_WhenGivenCollectionOfAcademyConversionProjectData_ShouldReturnCollectionOfTypeAcademyConversionProject()
    {
        var applications = TestData.GenerateCompleteA2BApplications(10).ToList();
        var establishments = TestData.GenerateCompleteEstablishments(10);

        var projectData = applications.Select(application => new AcademyConversionProjectInformation
        {
            Application = application,
            Establishments = new HashSet<Establishment>()
            {
                establishments.First(e => e.Urn == application.ApplyingSchools.First().Urn)
            }
        });
        
        var result = _mapper.Map(projectData);

        result.Should().BeAssignableTo<IEnumerable<AcademyConversionProject>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfAcademyConversionProjectInformation_ShouldReturnMappedCollectionOfAcademyConversionProjects()
    {
        var applications = TestData.GenerateCompleteA2BApplications(10).ToList();
        var establishments = TestData.GenerateCompleteEstablishments(10);

        var projectData = applications.Select(application => new AcademyConversionProjectInformation
        {
            Application = application,
            Establishments = new HashSet<Establishment>()
            {
                establishments.First(e => e.Urn == application.ApplyingSchools.First().Urn)
            }
        });

        var expected = TestData.GenerateCompleteAcademyConversionProjects(10);
        
        var result = _mapper.Map(projectData);
        
        result.Should().BeEquivalentTo(expected);
    }
};