using Platform;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.Configure<MessageOptions>(options =>
// {
//   options.CityName = "Albany";
// });

var app = builder.Build();

// app.Use(async (context, next) => // Modifies after calling next().
// {
//   await next();
//   await context.Response
//   .WriteAsync($"\nStatus Code: {context.Response.StatusCode}");
// });

// app.Use(async (context, next) => // Short-circuit middleware.
// {
//   if (context.Request.Path == "/short")
//   {
//     await context.Response
//     .WriteAsync($"Request Short Circuited");
//   }
//   else
//   {
//     await next();
//   }
// });

// app.Use(async (context, next) => // Custom middleware.
// {
//   if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
//   {
//     context.Response.ContentType = "text/plain";
//     await context.Response.WriteAsync("Custom Middleware \n");
//   }
//   await next();
// });

// ((IApplicationBuilder)app).Map("/branch", branch => // Pipeline branch.
// {
//   branch.UseMiddleware<Platform.QueryStringMiddleWare>();
//   branch.Run(async (context) => // Terminal middleware.
//     {
//       await context.Response.WriteAsync($"Branch Middleware");
//     });
// });

// app.MapWhen(context => context.Request.Query.Keys.Contains("branch"), // Branching with predicates.
//   branch =>
//   {
//     branch.Use(async (HttpContext context, Func<Task> next) =>
//     {
//       await context.Response.WriteAsync($"Branch with predicates.");
//     });
//   });

// app.MapGet("/location", async (HttpContext context, IOptions<MessageOptions> msgOpts) =>
// {
//   Platform.MessageOptions opts = msgOpts.Value;
//   await context.Response.WriteAsync($"{opts.CityName}, {opts.CountryName}");
// });

// app.Use(async (context, next) => // Custom middleware.
// {
//   if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
//   {
//     context.Response.ContentType = "text/plain";
//     await context.Response.WriteAsync("Custom Middleware \n");
//   }
//   await next();
// });

// app.UseMiddleware<QueryStringMiddleWare>();

// app.UseMiddleware<LocationMiddleware>();

// app.MapGet("/", () => "Hello World!");

app.UseMiddleware<Population>();
app.UseMiddleware<Capital>();
app.Run(async (context) =>
{
  await context.Response.WriteAsync("Terminal Middleware Reached");
});

app.Run();
