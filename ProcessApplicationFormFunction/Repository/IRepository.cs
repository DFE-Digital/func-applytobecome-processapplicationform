using ProcessApplicationFormFunction.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcessApplicationFormFunction.Repository;

public interface IRepository
{
    Task<IEnumerable<string>> GetApplicationIds();
    Task<IEnumerable<StagingApplication>> GetApplications(IEnumerable<string> applicationIds);
    Task AddApplications(IEnumerable<A2BApplication> applications);
}