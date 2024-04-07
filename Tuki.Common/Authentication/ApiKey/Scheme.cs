using Microsoft.AspNetCore.Authentication;
using Microsoft.Net.Http.Headers;

namespace Tuki.Common.Authentication.ApiKey;

public class ApiKeySchemeOptions : AuthenticationSchemeOptions
{
    public const string Scheme = "ApiKeyScheme";
    public string HeaderName { get; set; } = HeaderNames.Authorization;
}