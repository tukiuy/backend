using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace ApiCompras.Middleware
{
    public class ApiKeyMiddleware
    {

        private readonly RequestDelegate _next;
        private const string ApiKeyHeader = "XApiKey";


        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Verificar si la cabecera de la API key está presente
            if (!context.Request.Headers.TryGetValue(ApiKeyHeader, out var apiKeyValue))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API key no proporcionada");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var ValidApiKey = appSettings.GetValue<string>("XApiKey");

            // Verificar si la API key es válida
            if (!apiKeyValue.Equals(ValidApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("API key inválida");
                return;
            }

            // La API key es válida, pasar al siguiente middleware
            await _next(context);
        }

    }

    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
