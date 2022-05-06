using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProcessApplicationForm.Test.Data;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using ProcessApplicationFormFunction.Repository;
using Xunit;

namespace ProcessApplicationForm.Test.IntegrationTests;

public class ProcessApplicationFormTests
{
    private readonly Mock<HttpRequest> _mockRequest;
    private readonly Mock<IRepository> _mockRepository;
    private readonly Mock<IMapper<StagingApplication, A2BApplication>> _mockApplicationMapper;
    private readonly Mock<IMapper<A2BApplication, AcademyConversionProject>> _mockProjectMapper;
    private readonly Mock<ILogger> _mockLogger;

    public ProcessApplicationFormTests()
    {
        _mockLogger = new();
        _mockRequest = new();
        _mockRepository = new();
        _mockApplicationMapper = new();
        _mockProjectMapper = new();
    }

    [Fact]
    public async Task ProcessApplicationForm_WhenSuccessful_ReturnsOk()
    {
        var stagingApplications = TestData.GenerateCompleteStagingApplications(10).ToList();
        var a2BApplications = TestData.GenerateCompleteA2BApplications(10).ToList();
        var academyConversionProjects = TestData.GenerateCompleteAcademyConversionProjects(10).ToList();

        _mockRepository
            .Setup(r => r.GetA2BApplicationIds())
            .ReturnsAsync(Array.Empty<string>);

        _mockRepository
            .Setup(r => r.GetStagingApplications(It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(stagingApplications);

        _mockRepository
            .Setup(r => r.AddA2BApplications(a2BApplications));

        _mockRepository
            .Setup(r => r.AddAcademyConversionProjects(academyConversionProjects));

        _mockApplicationMapper
            .Setup(r => r.Map(stagingApplications))
            .Returns(a2BApplications);

        _mockProjectMapper
            .Setup(r => r.Map(a2BApplications))
            .Returns(academyConversionProjects);

        ProcessApplicationFormFunction.ProcessApplicationForm function =
            new(_mockRepository.Object, _mockApplicationMapper.Object, _mockProjectMapper.Object);

        var x = new ActionContext();

        var result = await function.RunAsync(_mockRequest.Object, _mockLogger.Object);

        result.Should().BeEquivalentTo(new OkResult());
    }

    [Fact]
     public async Task ProcessApplicationForm_WhenNoApplicationsToAdd_ReturnsOk_AndShouldNotCallMapperOrAddRepositoryMethods()
     {
         var stagingApplications = Array.Empty<StagingApplication>;

         _mockRepository
             .Setup(r => r.GetA2BApplicationIds())
             .ReturnsAsync(Array.Empty<string>);

         _mockRepository
             .Setup(r => r.GetStagingApplications(It.IsAny<IEnumerable<string>>()))
             .ReturnsAsync(stagingApplications);

         _mockRepository
             .Setup(r => r.AddA2BApplications(It.IsAny<IEnumerable<A2BApplication>>()));

         _mockApplicationMapper
             .Setup(r => r.Map(It.IsAny<IEnumerable<StagingApplication>>()));

         ProcessApplicationFormFunction.ProcessApplicationForm function = 
             new(_mockRepository.Object, _mockApplicationMapper.Object, _mockProjectMapper.Object);

         var result = await function.RunAsync(_mockRequest.Object, _mockLogger.Object);
         
         _mockApplicationMapper.Verify(m => m.Map(It.IsAny<IEnumerable<StagingApplication>>()), Times.Never);
         _mockProjectMapper.Verify(m => m.Map(It.IsAny<IEnumerable<A2BApplication>>()), Times.Never);
         _mockRepository.Verify(r => r.AddA2BApplications(It.IsAny<IEnumerable<A2BApplication>>()), Times.Never);
         _mockRepository.Verify(r => r.AddAcademyConversionProjects(It.IsAny<IEnumerable<AcademyConversionProject>>()), Times.Never);

         result.Should().BeEquivalentTo(new OkResult());
     }

     [Fact]
     public async Task ProcessApplicationForm_WhenNotSuccessful_ReturnsInternalServerError()
     {
         _mockRepository
             .Setup(r => r.GetA2BApplicationIds())
             .ThrowsAsync(new DBConcurrencyException());

         ProcessApplicationFormFunction.ProcessApplicationForm function = 
             new(_mockRepository.Object, _mockApplicationMapper.Object, _mockProjectMapper.Object);

         var result = await function.RunAsync( _mockRequest.Object, _mockLogger.Object);

         result.Should().BeEquivalentTo(new InternalServerErrorResult());
     }
 }