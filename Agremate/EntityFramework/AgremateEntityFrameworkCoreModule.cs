using Agremate.Domain.Samples;
using Agremate.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Agremate.EntityFramework;

public static class AgremateEntityFrameworkCoreModule
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<AgremateDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ISampleRepository, SampleRepository>();
    }
}
