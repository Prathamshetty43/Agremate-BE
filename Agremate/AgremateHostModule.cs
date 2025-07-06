using Agremate.ApplicationContracts.ServiceInterfaces;
using Agremate.Applications;
using Agremate.EntityFramework;
using StackExchange.Redis;

namespace Agremate;

public static class AgremateHostModule
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        AgremateEntityFrameworkCoreModule.ConfigureServices(services, configuration);

        services.AddScoped<ISampleService, SampleService>();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var redisConfig = configuration.GetSection("Redis")["Configuration"];
        services.AddSingleton<IConnectionMultiplexer>(
            ConnectionMultiplexer.Connect(redisConfig));
    }

    public static void ConfigureApplication(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
