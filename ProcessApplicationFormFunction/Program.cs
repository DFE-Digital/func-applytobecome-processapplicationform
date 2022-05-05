using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProcessApplicationFormFunction.Database;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Mappers;
using ProcessApplicationFormFunction.Repository;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddDbContext<SipDbContext>();
        services.AddScoped<IRepository, SqlRepository>();
        services.AddSingleton<IMapper<StagingApplication, A2BApplication>, ApplicationMapper>();
        services.AddSingleton<IMapper<StagingKeyPerson, A2BApplicationKeyPerson>, KeyPersonMapper>();
        services.AddSingleton<IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool>, ApplyingSchoolMapper>();
        services.AddSingleton<IMapper<StagingSchoolLoan, A2BSchoolLoan>, SchoolLoanMapper>();
        services.AddSingleton<IMapper<StagingSchoolLease, A2BSchoolLease>, SchoolLeaseMapper>();
        services.AddSingleton<IMapper<A2BApplication, AcademyConversionProject>, ProjectMapper>();
    })
    .Build();

host.Run();
