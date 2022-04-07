using System;
using Microsoft.EntityFrameworkCore;
using ProcessApplicationFormFunction.Database.Models;

namespace ProcessApplicationFormFunction.Database;

public class SipDbContext : DbContext
{
    private const string ConnectionStringName = "SQLAZURECONNSTR_SqlConnectionString";
    private const string ConfigurationMissing = "Could not retrieve connection string from function app configuration";
    
    public SipDbContext(DbContextOptions<SipDbContext> options) : base(options) {}

    public virtual DbSet<StagingApplication> DynamicsApplications { get; set; }
    public virtual DbSet<StagingKeyPerson> DynamicsKeyPerson { get; set; }
    public virtual DbSet<StagingApplyingSchool> DynamicsApplyingSchools { get; set; }
    public virtual DbSet<StagingSchoolLease> DynamicsSchoolLeases { get; set; }
    public virtual DbSet<StagingSchoolLoan> DynamicsSchoolLoans { get; set; }
    
    public virtual DbSet<A2BApplication> A2BApplications { get; set; }
    public virtual DbSet<A2BApplicationKeyPerson> A2BApplicationKeyPersons { get; set; }
    public virtual DbSet<A2BApplicationApplyingSchool> A2BApplicationApplyingSchools { get; set; }
    public virtual DbSet<A2BSchoolLease> A2BApplicationSchoolLeases{ get; set; }
    public virtual DbSet<A2BSchoolLoan> A2BApplicationSchoolLoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        
        var connectionString = Environment.GetEnvironmentVariable(ConnectionStringName) 
                               ?? throw new ApplicationException(ConfigurationMissing);
        optionsBuilder.UseSqlServer(connectionString);
    }
}