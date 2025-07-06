using Agremate.ApplicationContracts.ServiceInterfaces;
using Agremate.Applications;
using Agremate.EntityFramework;
using Agremate.Domain.Samples; 
using Agremate.EntityFramework.Repositories; 

var builder = WebApplication.CreateBuilder(args);

AgremateEntityFrameworkCoreModule.ConfigureServices(builder.Services, builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISampleService, SampleService>();
builder.Services.AddScoped<ISampleRepository, SampleRepository>(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
