using Platform.Services;

namespace Platform
{
  public class WeatherMiddleware // Scoped Service example. 
  {
    private RequestDelegate next;
    // private IResponseFormatter formatter;
    public WeatherMiddleware(RequestDelegate nextDelegate)
    {
      next = nextDelegate;
      // formatter = responseFormatter;
    }
    public async Task Invoke(HttpContext context, IResponseFormatter formatter1,
    IResponseFormatter formatter2, IResponseFormatter formatter3) // 3 Dependencies on same service.
    {
      if (context.Request.Path == "/middleware/class")
      {
        await formatter1.Format(context, string.Empty);
        await formatter2.Format(context, string.Empty);
        await formatter3.Format(context, string.Empty);
      }
      else
      {
        await next(context);
      }
    }
  }
}
