using Platform;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

//Ref https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-logging/?view=aspnetcore-6.0
builder.Services.AddHttpLogging(opts => {
 opts.LoggingFields = 
 HttpLoggingFields.RequestMethod | 
 HttpLoggingFields.RequestPath | 
 HttpLoggingFields.ResponseStatusCode;
});

var app = builder.Build();

app.UseHttpLogging();

//var logger = app.Services
// .GetRequiredService<ILoggerFactory>().CreateLogger("Pipeline");
//logger.LogDebug("Pipeline configuration starting");

app.MapGet("population/{city?}", Population.Endpoint);

//logger.LogDebug("Pipeline configuration complete");

app.Run();