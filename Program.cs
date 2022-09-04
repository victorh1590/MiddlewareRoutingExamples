// using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);

//IWebHostEnvironment env = builder.Environment;
IConfiguration config = builder.Configuration;

builder.Services.AddScoped<IResponseFormatter, TextResponseFormatter>();
builder.Services.AddScoped<IResponseFormatter, HtmlResponseFormatter>();
builder.Services.AddScoped<IResponseFormatter, GuidService>();

var app = builder.Build();

app.MapGet("single", async context =>
{
  IResponseFormatter formatter = context.RequestServices
  .GetRequiredService<IResponseFormatter>(); // Uses most recent implementation -> GuidService.
  await formatter.Format(context, "Single service");
});

app.MapGet("/", async context =>
{
  IResponseFormatter formatter = context.RequestServices
  .GetServices<IResponseFormatter>().First(f => f.RichOutput); // Select first implementation with RichOutput == true;
  await formatter.Format(context, "Multiple services");
});

app.Run();