namespace Platform.Services
{
  public interface IResponseFormatter
  {
    Task Format(HttpContext context, string content);
    public bool RichOutput => false; // Will be false if no override.
  }
}
