using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ProcessApplicationFormFunction;
using ProcessApplicationFormFunction.Database;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using ProcessApplicationFormFunction.Repository;

[assembly: FunctionsStartup(typeof( ProcessApplicationFormFunction.Startup))]
namespace ProcessApplicationFormFunction;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddDbContext<SipDbContext>();
        builder.Services.AddScoped<IRepository, SqlRepository>();
        builder.Services.AddSingleton<IMapper<StagingApplication, A2BApplication>, ApplicationMapper>();
        builder.Services.AddSingleton<IMapper<StagingKeyPerson, A2BApplicationKeyPerson>, KeyPersonMapper>();
        builder.Services.AddSingleton<IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool>, ApplyingSchoolMapper>();
        builder.Services.AddSingleton<IMapper<StagingSchoolLoan, A2BSchoolLoan>, SchoolLoanMapper>();
        builder.Services.AddSingleton<IMapper<StagingSchoolLease, A2BSchoolLease>, SchoolLeaseMapper>();
        builder.Services.AddSingleton<IMapper<A2BApplication, AcademyConversionProject>, AcademyConversionProjectMapper>();
        builder.Services.AddSingleton<IMapper<A2BApplication, AcademisationProject>, ProjectMapper>();
    }
}