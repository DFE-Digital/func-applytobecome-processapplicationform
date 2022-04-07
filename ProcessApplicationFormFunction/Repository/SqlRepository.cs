using ProcessApplicationFormFunction.Database;
using ProcessApplicationFormFunction.Database.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProcessApplicationFormFunction.Mappers;

namespace ProcessApplicationFormFunction.Repository;

public class SqlRepository : IRepository
{
    private readonly SipDbContext _context;
    private readonly IMapper<StagingApplication, A2BApplication> _mapper;

    public SqlRepository(SipDbContext context, IMapper<StagingApplication, A2BApplication> mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task AddApplications(IEnumerable<A2BApplication> applications)
    {
        _context.A2BApplications.AddRange(applications);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<string>> GetApplicationIds()
    {
        return await _context.A2BApplications
               .Select(app => app.ApplicationId)
               .ToListAsync();
     }

    public async Task<IEnumerable<StagingApplication>> GetApplications(IEnumerable<string> existingApplicationIds)
    {
        var input = await _context.DynamicsApplications
               .AsNoTracking()
               .Include(da => da.KeyPersons)
               .Include(da => da.ApplyingSchools)
               .ThenInclude(ap => ap.SchoolLoans)
               .Include(da => da.ApplyingSchools)
               .ThenInclude(ap => ap.SchoolLeases)
               .Where(ap => !existingApplicationIds.Contains(ap.Name))
               .AsSingleQuery()
               .ToListAsync();
        _mapper.Map(input);
        return input;
    }
}

