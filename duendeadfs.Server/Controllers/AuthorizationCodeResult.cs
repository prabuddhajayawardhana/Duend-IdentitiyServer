using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;

namespace IdentityServer.Controllers
{
    internal class AuthorizationCodeResult
    {
        public bool IsSuccessful { get; set; }
        public string RedirectUri { get; set; }
        public string AccessToken { get; set; }
        public string IdToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public object UserInfo { get; set; }
        public TokenValidationResult ClaimsPrincipal { get; set; }
        public string? Error { get; internal set; }
        public string? ErrorDescription { get; internal set; }
    }
}