using System;
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

        var result = _mapper.Map(applications);

        result.Should().BeAssignableTo<IEnumerable<AcademyConversionProject>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfAcademyConversionProjectInformation_ShouldReturnMappedCollectionOfAcademyConversionProjects()
    {
        var applications = TestData.GenerateCompleteA2BApplications(10).ToList();
        
        var expected = TestData.GenerateCompleteAcademyConversionProjects(10).ToList();
        
        var result = _mapper.Map(applications).ToList();
        
        result.Should().BeEquivalentTo(expected);
    }
};