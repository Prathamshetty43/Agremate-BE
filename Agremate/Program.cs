using Agremate;

var builder = WebApplication.CreateBuilder(args);

AgremateHostModule.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

AgremateHostModule.ConfigureApplication(app);

app.Run();

