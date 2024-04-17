using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace IdentityServer.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        [Route("/authentication/callback")]
        public async Task<IActionResult> Callback(string code, string scope , string state)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            // Process the authorization code and exchange it for tokens
            //var result = await ProcessAuthorizationCodeAsync(code);
            return Ok("log in");
        }

        //private async Task<AuthorizationCodeResult> ProcessAuthorizationCodeAsync(string code)
        //{
        //    // Validate the authorization code and exchange it for tokens
        //    var tokenResponse = await _tokenValidator.ValidateAuthorizationCodeAsync(code);

        //    if (tokenResponse.IsError)
        //    {
        //        // Handle the error
        //        return new AuthorizationCodeResult
        //        {
        //            IsSuccessful = false,
        //            Error = tokenResponse.Error,
        //            ErrorDescription = tokenResponse.ErrorDescription
        //        };
        //    }

        //    // Process the tokens and store them as needed
        //    var accessToken = tokenResponse.AccessToken;
        //    var idToken = tokenResponse.IdentityToken;
        //    var refreshToken = tokenResponse.RefreshToken;

        //    // Optionally, get user information from the UserInfo endpoint
        //    var userInfoResponse = await _clientStore.GetUserInfoAsync(new UserInfoRequest
        //    {
        //        Address = tokenResponse.IdentityToken,
        //        Token = accessToken
        //    });

        //    // Optionally, validate the ID token
        //    var claimsPrincipal = await _tokenValidator.ValidateIdentityTokenAsync(idToken);

        //    // Return a successful result
        //    return new AuthorizationCodeResult
        //    {
        //        IsSuccessful = true,
        //        RedirectUri = "/",
        //        AccessToken = accessToken,
        //        IdToken = idToken,
        //        RefreshToken = refreshToken,
        //        UserInfo = userInfoResponse?.Claims,
        //        ClaimsPrincipal = claimsPrincipal
        //    };
        //}
    }
}
