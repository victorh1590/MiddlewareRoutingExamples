using Platform;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Logger.LogDebug("Pipeline configuration starting");

var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("Pipeline"); // Custom Logger.

logger.LogDebug("Pipeline configuration starting");

app.MapGet("population/{city?}", Population.Endpoint);

logger.LogDebug("Pipeline configuration complete");

app.Logger.LogDebug("Pipeline configuration complete");

app.Run();