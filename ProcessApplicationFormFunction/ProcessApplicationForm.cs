using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ProcessApplicationFormFunction.Database;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using ProcessApplicationFormFunction.Repository;

namespace ProcessApplicationFormFunction;

public class ProcessApplicationForm
{
    private readonly IRepository _repository;
    private readonly IMapper<StagingApplication, A2BApplication> _mapper;

    public ProcessApplicationForm(IRepository repository, IMapper<StagingApplication, A2BApplication> mapper)
    {
        _repository = repository;
        _mapper = mapper;
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
                var mappedApplications = _mapper.Map(applications);
                await _repository.AddA2BApplications(mappedApplications);
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