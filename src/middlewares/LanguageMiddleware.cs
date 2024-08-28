namespace MovieAppApi.middlewares;

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class LanguageMiddleware
{
  private readonly RequestDelegate _next;
  public LanguageMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    var language = context.Request.Query["language"].ToString();
    // Si no se proporciona, establece un valor por defecto
    if (string.IsNullOrEmpty(language))
    {
        language = "es"; // Por defecto español
    }
    context.Items["language"] = language;
    await _next(context);
  }
}