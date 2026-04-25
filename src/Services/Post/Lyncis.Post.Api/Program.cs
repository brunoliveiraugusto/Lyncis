using Lyncis.Post.Application;
using Lyncis.Post.Infrastructure;
using Lyncis.Shared.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSharedInfrastructure();
builder.Services.AddLyncisTelemetry("Lyncis.Post");
builder.Logging.AddLyncisLogging(builder.Configuration, "Lyncis.Post");
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseExceptionHandler();

app.MapHealthChecks("/api/posts/health");
app.MapControllers();
app.Run();
