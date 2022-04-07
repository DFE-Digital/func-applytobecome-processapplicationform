using ProcessApplicationFormFunction.Database;
using ProcessApplicationFormFunction.Database.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProcessApplicationFormFunction.Repository;

public class SqlRepository : IRepository
{
    private readonly SipDbContext _context;

    public SqlRepository(SipDbContext context) => _context = context; 
    
    public async Task AddA2BApplications(IEnumerable<A2BApplication> applications)
    {
        _context.A2BApplications.AddRange(applications);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<string>> GetA2BApplicationIds() =>
        await _context.A2BApplications
            .Select(app => app.ApplicationId)
            .ToListAsync();

    public async Task<IEnumerable<StagingApplication>> GetStagingApplications(IEnumerable<string> existingApplicationIds) =>
        await _context.DynamicsApplications
            .AsNoTracking()
            .Include(da => da.KeyPersons)
            .Include(da => da.ApplyingSchools)
            .ThenInclude(ap => ap.SchoolLoans)
            .Include(da => da.ApplyingSchools)
            .ThenInclude(ap => ap.SchoolLeases)
            .Where(ap => !existingApplicationIds.Contains(ap.ApplicationId))
            .AsSingleQuery()
            .ToListAsync();
}

