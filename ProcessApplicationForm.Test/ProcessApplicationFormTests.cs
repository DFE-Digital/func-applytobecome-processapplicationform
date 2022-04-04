using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ProcessApplicationForm.Test;

public class ProcessApplicationFormTests
{
    private readonly Mock<FunctionContext> _mockContext;
    private readonly Mock<HttpRequestData> _mockRequest;
    
    public ProcessApplicationFormTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped<ILoggerFactory, LoggerFactory>();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        _mockContext = new Mock<FunctionContext>();
        _mockContext.SetupProperty(c => c.InstanceServices, serviceProvider);
        
        _mockRequest = new Mock<HttpRequestData>(_mockContext.Object);
        _mockRequest.Setup(r => r.CreateResponse()).Returns(() =>
        {
            var response = new Mock<HttpResponseData>(_mockContext.Object);
            response.SetupProperty(r => r.Headers, new HttpHeadersCollection());
            response.SetupProperty(r => r.StatusCode);
            response.SetupProperty(r => r.Body, new MemoryStream());

            return response.Object;
        });
    }
    
    [Fact]
    public async Task ProcessApplicationForm_WhenSuccessful_ReturnsOk()
    {
        var function = new ProcessApplicationFormFunction.ProcessApplicationForm();

        var result = await function.Process( _mockRequest.Object, _mockContext.Object);

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
}