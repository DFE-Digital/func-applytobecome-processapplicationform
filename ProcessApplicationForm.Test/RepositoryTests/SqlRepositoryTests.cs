using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ProcessApplicationForm.Test.Data;
using ProcessApplicationFormFunction.Database;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Repository;
using Xunit;

namespace ProcessApplicationForm.Test.RepositoryTests;

public class SqlRepositoryTests
{
    private static SipDbContext CreateSingleTestContext()
    {
        var contextOptions = new DbContextOptionsBuilder<SipDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .Options;

        return new(contextOptions);
    }
    
    [Fact]
    public async Task GetStagingApplications_WithNoExistingApplications_ShouldReturnAllAddedApplications()
    {
        var context = CreateSingleTestContext();
        SqlRepository repository = new(context);
        
        const int count = 10;
        var applications = TestData.GenerateCompleteStagingApplications(count).ToList();
        await context.DynamicsApplications.AddRangeAsync(applications);
        await context.SaveChangesAsync();

        var results = (await repository.GetStagingApplications(Array.Empty<string>())).ToList();


        results.Should().HaveCount(count);
        results.Should().BeEquivalentTo(applications);

        await context.DisposeAsync();
    }

    [Fact]
    public async Task GetStagingApplications_WithExistingApplications_ShouldReturnOnlyNewApplications()
    {
        var context = CreateSingleTestContext();
        SqlRepository repository = new(context);
        
        const int count = 10;
        const int existingCount = 2;
        const int expectedCount = count - existingCount;
        
        var applications = TestData.GenerateCompleteStagingApplications(count).ToList();
        await context.DynamicsApplications.AddRangeAsync(applications);
        await context.SaveChangesAsync();

        var existingApplicationIds = applications
            .OrderBy(a => a.Name)
            .Select(a => a.Name)
            .Take(existingCount);
        
        var expected = applications
            .OrderBy(a => a.Name)
            .Skip(existingCount);
        
        var results = (await repository.GetStagingApplications(existingApplicationIds)).ToList();
        
        results.Should().HaveCount(expectedCount);
        results.Should().BeEquivalentTo(expected);

        await context.DisposeAsync();
    }

    [Fact]
    public async Task GetStagingApplications_WithNoStagingApplication_ShouldReturnEmptyList()
    {
        var context = CreateSingleTestContext();
        SqlRepository repository = new(context);
        
        var results = await repository.GetStagingApplications(Array.Empty<string>());

        results.Should().BeEmpty();

        await context.DisposeAsync();
    }

    [Fact]
    public async Task GetA2BApplicationIds_WithExistingApplications_ShouldReturnThoseIds()
    {
        var context = CreateSingleTestContext();
        SqlRepository repository = new(context);
        
        const int count = 10;
        var applications = TestData.GenerateCompleteA2BApplications(count).ToList();
        await context.A2BApplications.AddRangeAsync(applications);
        await context.SaveChangesAsync();

        var expected = applications.Select(a => a.ApplicationId).ToArray();

        var results = (await repository.GetA2BApplicationIds()).ToArray();
        
        results.Should().HaveCount(count);
        results.Should().BeEquivalentTo(expected);

        await context.DisposeAsync();
    }

    [Fact]
    public async Task AddA2BApplications_WithEmptyCollectionOfA2BApplications_ShouldNotCreateAnyRecordsInDatabase()
    {
        var context = CreateSingleTestContext();
        SqlRepository repository = new(context);

        await repository.AddA2BApplications(new HashSet<A2BApplication>());

        var expected = context.A2BApplications;

        expected.Should().BeEmpty();
    }

    [Fact]
    public async Task A2BApplications_WithCollectionOfApplications_ShouldCreateThoseRecordsInDatabase()
    {
        var context = CreateSingleTestContext();
        SqlRepository repository = new(context);

        const int count = 10;
        
        var applications = TestData.GenerateCompleteA2BApplications(count).ToList();

        await repository.AddA2BApplications(applications);

        var results = await context.A2BApplications
            .Include(a => a.KeyPersons)
            .Include(a => a.ApplyingSchools)
            .ThenInclude(a => a.SchoolLoans)
            .Include(a => a.ApplyingSchools)
            .ThenInclude(a => a.SchoolLoans)
            .AsSingleQuery()
            .ToListAsync();

        results.Should().HaveCount(count);
        results.Should().BeEquivalentTo(applications);
    }
}