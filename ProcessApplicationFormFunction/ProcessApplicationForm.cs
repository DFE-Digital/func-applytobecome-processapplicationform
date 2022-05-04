using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using ProcessApplicationFormFunction.Repository;

namespace ProcessApplicationFormFunction;

public class ProcessApplicationForm
{
    private readonly IRepository _repository;
    private readonly IMapper<StagingApplication, A2BApplication> _applicationMapper;
    private readonly IMapper<A2BApplication, AcademyConversionProject> _projectMapper;

    public ProcessApplicationForm(
        IRepository repository, 
        IMapper<StagingApplication, A2BApplication> applicationMapper,
        IMapper<A2BApplication, AcademyConversionProject> projectMapper
        )
    {
        _repository = repository;
        _applicationMapper = applicationMapper;
        _projectMapper = projectMapper;
    }

    [Function(nameof(ProcessApplicationForm))]
    public async Task<HttpResponseData> Process([HttpTrigger(AuthorizationLevel.Function, "get")] 
        HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger(nameof(ProcessApplicationForm));

        logger.LogInformation("Executed {Name} with Id: {Id}", nameof(ProcessApplicationForm), executionContext.InvocationId);
        
        var response = req.CreateResponse(HttpStatusCode.OK);

        try
        {
            var applicationIds = await _repository.GetA2BApplicationIds();
            var applications = (await _repository.GetStagingApplications(applicationIds)).ToList();

            if (applications.Any())
            {
                var mappedApplications = _applicationMapper.Map(applications).ToList();
                await _repository.AddA2BApplications(mappedApplications);
                
                logger.LogInformation("Created {Count} applications in database", mappedApplications.Count);

                var mappedProjects = _projectMapper.Map(mappedApplications);
                await _repository.AddAcademyConversionProjects(mappedProjects);
                
                logger.LogInformation("Created {Count} projects in database", mappedApplications.Count);
            }
        }
        catch (Exception e)
        {
            var exceptionId = Guid.NewGuid();
            logger.LogError(e, "Exception Thrown with Id: {Id}", exceptionId);
            response.StatusCode = HttpStatusCode.InternalServerError;
            await response.WriteStringAsync($"An unexpected internal error has occured ({exceptionId})");
        }

        return response;
    }
}