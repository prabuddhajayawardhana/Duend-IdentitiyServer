using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Duende.IdentityServer.Validation;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IClientStore _clientStore;
        private readonly IEventService _events;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IResourceStore _resourceStore;
        private readonly ITokenValidator _tokenValidator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IResourceStore resourceStore,
            ITokenValidator tokenValidator,
            IEventService events,
            ILogger<AccountController> logger)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _resourceStore = resourceStore;
            _tokenValidator = tokenValidator;
            _events = events;
            _logger = logger;
        }

        [HttpGet]
        [Route("/authentication/callback")]
        public async Task<IActionResult> Callback(string code, string state)
        {
            // Process the authorization code and exchange it for tokens
            var result = await ProcessAuthorizationCodeAsync(code);

            if (result.IsSuccessful)
            {
                // Redirect or return a success response
                return Redirect(result.RedirectUri);
            }
            else
            {
                // Handle the error, e.g., return a bad request response
                return BadRequest(result.Error);
            }
        }

        private async Task<AuthorizationCodeResult> ProcessAuthorizationCodeAsync(string code)
        {
            // Validate the authorization code and exchange it for tokens
            var tokenResponse = await _tokenValidator.ValidateAccessTokenAsync(code);

            if (tokenResponse.IsError)
            {
                // Handle the error
                return new AuthorizationCodeResult
                {
                    IsSuccessful = false,
                    Error = tokenResponse.Error,
                    ErrorDescription = tokenResponse.ErrorDescription
                };
            }

            // Process the tokens and store them as needed
            var accessToken = tokenResponse.Jwt;
            var idToken = tokenResponse.ReferenceTokenId;
            var refreshToken = tokenResponse.RefreshToken;

            // Optionally, get user information from the UserInfo endpoint
            //var userInfoResponse = await _clientStore.GetUserInfoAsync(new UserInfoRequest
            //{
            //    Address = tokenResponse.Jwt,
            //    Token = accessToken
            //});

            // Optionally, validate the ID token
            var claimsPrincipal = await _tokenValidator.ValidateIdentityTokenAsync(idToken);

            // Return a successful result
            return new AuthorizationCodeResult
            {
                IsSuccessful = true,
                RedirectUri = "/",
                AccessToken = accessToken,
                IdToken = idToken,
                RefreshToken = refreshToken,
              //  UserInfo = userInfoResponse?.Claims,
                ClaimsPrincipal = claimsPrincipal
            };
        }
    }
}
