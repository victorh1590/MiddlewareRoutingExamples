var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) => // Modifies after calling next().
{
  await next();
  await context.Response
  .WriteAsync($"\nStatus Code: {context.Response.StatusCode}");
});

app.Use(async (context, next) => // Short-circuit middleware.
{
  if (context.Request.Path == "/short")
  {
    await context.Response
    .WriteAsync($"Request Short Circuited");
  }
  else
  {
    await next();
  }
});

app.Use(async (context, next) => // Custom middleware.
{
  if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
  {
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync("Custom Middleware \n");
  }
  await next();
});

((IApplicationBuilder)app).Map("/branch", branch => // Pipeline branch.
{
  // branch.UseMiddleware<Platform.QueryStringMiddleWare>();
  // branch.Run(async (context) => // Terminal middleware.
  //   {
  //     await context.Response.WriteAsync($"Branch Middleware");
  //   });
  branch.Run(new Platform.QueryStringMiddleWare().Invoke); // Terminal class-middleware.
});

app.MapWhen(context => context.Request.Query.Keys.Contains("branch"), // Branching with predicates.
  branch =>
  {
    branch.Use(async (HttpContext context, Func<Task> next) =>
    {
      await context.Response.WriteAsync($"Branch with predicates.");
    });
  });

app.UseMiddleware<Platform.QueryStringMiddleWare>(); // Class middleware example.

app.MapGet("/", () => "Hello World!");

app.Run();
