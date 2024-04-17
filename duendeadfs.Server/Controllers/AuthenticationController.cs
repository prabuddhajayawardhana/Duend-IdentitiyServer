
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    public class AccountController : Controller
    {
       
        [HttpGet]
        [Route("/authentication/callback")]
        public async Task<IActionResult> Callback(string code, string scope, string state)
        {
            return Redirect("http://localhost:5173/Profile");
        }

        //private async Task<AuthorizationCodeResult> ProcessAuthorizationCodeAsync(string code)
        //{
        //    // Validate the authorization code and exchange it for tokens
        //    var tokenResponse = await _tokenValidator.ValidateAccessTokenAsync(code);

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
        //    var accessToken = tokenResponse.Jwt;
        //    var idToken = tokenResponse.ReferenceTokenId;
        //    var refreshToken = tokenResponse.RefreshToken;

        //    // Optionally, get user information from the UserInfo endpoint
        //    //var userInfoResponse = await _clientStore.GetUserInfoAsync(new UserInfoRequest
        //    //{
        //    //    Address = tokenResponse.Jwt,
        //    //    Token = accessToken
        //    //});

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
        //      //  UserInfo = userInfoResponse?.Claims,
        //        ClaimsPrincipal = claimsPrincipal
        //    };
        //}
    }
}
