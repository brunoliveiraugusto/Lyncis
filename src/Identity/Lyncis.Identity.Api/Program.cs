using Lyncis.Identity.Infrastructure;
using Lyncis.Shared.DI;
using Lyncis.Identity.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSharedInfrastructure();
builder.Services.AddLyncisTelemetry("Lyncis.Identity");
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseExceptionHandler();

app.MapHealthChecks("/api/identity/health");
app.MapControllers();
app.Run();