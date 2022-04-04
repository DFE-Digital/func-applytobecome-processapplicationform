using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ProcessApplicationFormFunction;

public class ProcessApplicationForm
{
    [Function(nameof(ProcessApplicationForm))]
    public async Task<HttpResponseData> Process([HttpTrigger(AuthorizationLevel.Function, "get")] 
        HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger(nameof(ProcessApplicationForm));

        logger.LogInformation("Executed {Name} with Id: {Id}", nameof(ProcessApplicationForm), executionContext.InvocationId);
        
        var response = req.CreateResponse(HttpStatusCode.OK);
        
        return await Task.FromResult(response);
    }
}