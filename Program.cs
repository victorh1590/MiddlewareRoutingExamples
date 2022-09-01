using Platform;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<Population>();
app.UseMiddleware<Capital>();

// app.MapGet("routing", async context =>
//   {
//     await context.Response.WriteAsync("Request Was Routed1");
//   });

app.UseRouting();
app.UseEndpoints(endpoints =>
{
  endpoints.MapGet("routing", async context =>
  {
    await context.Response.WriteAsync("Request Was Routed");
  });
  endpoints.MapGet("capital/uk", new Capital().Invoke);
  endpoints.MapGet("population/paris", new Population().Invoke);
});

app.Run(async (context) =>
{
  await context.Response.WriteAsync("Terminal Middleware Reached");
});

app.Run();
