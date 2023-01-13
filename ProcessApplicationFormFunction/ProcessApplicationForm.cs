using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Logging;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using ProcessApplicationFormFunction.Repository;


namespace ProcessApplicationFormFunction;

public class ProcessApplicationForm
{
   private readonly IRepository _repository;
   private readonly IMapper<StagingApplication, A2BApplication> _applicationMapper;
   private readonly IMapper<A2BApplication, AcademyConversionProject> _academyConversionMapper;
   private readonly IMapper<A2BApplication, AcademisationProject> _projectMapper;


   public ProcessApplicationForm(
      IRepository repository,
      IMapper<StagingApplication, A2BApplication> applicationMapper,
      IMapper<A2BApplication, AcademyConversionProject> academyConversionMapper,
      IMapper<A2BApplication, AcademisationProject> projectMapper
   )
   {
      _repository = repository;
      _applicationMapper = applicationMapper;
      _academyConversionMapper = academyConversionMapper;
      _projectMapper = projectMapper;
   }

   [FunctionName("ProcessApplicationForm")]
   public async Task<IActionResult> RunAsync(
      [HttpTrigger(AuthorizationLevel.Function)] HttpRequest req, ILogger log)
   {

      log.LogInformation("Executed {Name}", nameof(ProcessApplicationForm));

      try
      {
         var applicationIds = await _repository.GetA2BApplicationIds();
         var applications = (await _repository.GetStagingApplications(applicationIds)).ToList();

         if (applications.Any())
         {
            var mappedApplications = _applicationMapper.Map(applications).ToList();
            await _repository.AddA2BApplications(mappedApplications);

            log.LogInformation("Created {Count} applications in database", mappedApplications.Count);
            
            // Change to filter out none submitted applications if the data factory pipeline is change to not include only submitted applications
            var submittedMappedApplication = mappedApplications.Where(x => x.ApplicationSubmitted is true).ToList();

            var mappedAcademyConversionProjects = _academyConversionMapper.Map(submittedMappedApplication);
            var mappedProjects = _projectMapper.Map(submittedMappedApplication);

            await _repository.AddAcademyConversionProjects(mappedAcademyConversionProjects);
            await _repository.AddAcademisationProjects(mappedProjects);

            log.LogInformation("Created {Count} projects in database", mappedApplications.Count);
         }
      }
      catch (Exception e)
      {
         var exceptionId = Guid.NewGuid();
         log.LogError(e, "Exception Thrown with Id: {Id}", exceptionId);
         return new ObjectResult($"An unexpected internal error has occured ({exceptionId})")
         {
            StatusCode = 500
         };
      }

      return new OkResult();
   }
}