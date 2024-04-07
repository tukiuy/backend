
using Microsoft.Extensions.DependencyInjection;

namespace Tuki.Common.Authentication.ApiKey;

public static class ApiKeyExtension
{
    public static IServiceCollection AddApiKeyAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(ApiKeySchemeOptions.Scheme)
            .AddScheme<ApiKeySchemeOptions, ApiKeySchemeHandler>(
                ApiKeySchemeOptions.Scheme, options =>
                {
                    options.HeaderName = "X-API-KEY";
                }
            );

        return services;
    }
}
