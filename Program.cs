using Platform;

var builder = WebApplication.CreateBuilder(args);

var servicesConfig = builder.Configuration;
// - use configuration settings to set up services

builder.Services.Configure<MessageOptions>(servicesConfig.GetSection("Location"));

var app = builder.Build();

var pipelineConfig = app.Configuration;
// - use configuration settings to set up pipeline

app.UseMiddleware<LocationMiddleware>();

app.MapGet("config", async (HttpContext context, IConfiguration config) =>
{
  string defaultDebug = config["Logging:LogLevel:Default"];
  await context.Response
  .WriteAsync($"The config setting is: {defaultDebug}");
});

app.Run();