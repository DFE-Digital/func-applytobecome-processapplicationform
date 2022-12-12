using ProcessApplicationFormFunction.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcessApplicationFormFunction.Repository;

public interface IRepository
{
    Task<IEnumerable<string>> GetA2BApplicationIds();
    Task<IEnumerable<StagingApplication>> GetStagingApplications(IEnumerable<string> applicationIds);
    Task AddA2BApplications(IEnumerable<A2BApplication> applications);
    Task AddAcademyConversionProjects(IEnumerable<AcademyConversionProject> projects);
    Task AddAcademisationProjects(IEnumerable<AcademisationProject> projects);
}