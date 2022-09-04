using Platform.Services;

namespace Platform
{
  public class WeatherEndpoint
  {
    public static async Task Endpoint(HttpContext context)
    {
      IResponseFormatter formatter = // Resolves dependency everytime something is routed to this endpoint.
        context.RequestServices.GetRequiredService<IResponseFormatter>();
      await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");

    }
  }
}