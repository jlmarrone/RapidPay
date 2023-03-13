using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using RapidPay.Abstractions.Services;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace RapidPay.API.Authentication
{
    public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        #region Property  
        private readonly IUserService _userService;
        #endregion

        #region Constructor  
        public AuthenticationHandler(IUserService userService,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }
        #endregion

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string role;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                var user = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();

                var validCredentials = await _userService.ValidateCredentialsExistenceAsync(user, password);

                if (!validCredentials)
                {
                    throw new ArgumentException("Invalid credentials. Please check them");
                }

                role = await _userService.GetRoleByUserNameAsync(user);
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
            }

            var claims = new[] { new Claim(ClaimTypes.Role, role) };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
