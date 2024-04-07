using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Tuki.Common.Authentication.ApiKey;

public class ApiKeySchemeHandler(
    IOptionsMonitor<ApiKeySchemeOptions> options,
    IConfiguration configuration,
    ILoggerFactory logger,
    UrlEncoder encoder,
    ISystemClock clock) : AuthenticationHandler<ApiKeySchemeOptions>(options, logger, encoder, clock)
{
    private readonly IConfiguration configuration = configuration;

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(Options.HeaderName, out Microsoft.Extensions.Primitives.StringValues value))
        {
            return AuthenticateResult.Fail("Header Not Found.");
        }

        var headerValue = value;

        var apiKey = configuration["ApiKey"];
        if (apiKey is null)
        {
            return AuthenticateResult.Fail("No ApiKey configured in the application.");
        }
     
        var claims = new Claim[]
        {
            new(ClaimTypes.NameIdentifier, "None"),
            new(ClaimTypes.Name, apiKey)
        };

        var identiy = new ClaimsIdentity(claims, nameof(ApiKeySchemeHandler));
        var principal = new ClaimsPrincipal(identiy);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}