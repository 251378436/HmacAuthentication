using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;

namespace Server.Auth
{
    public class CustomTokenAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        string keyId = "65d3a4f0-0239-404c-8394-21b94ff50604";
        string keySecrect = "WLUEWeL3so2hdHhHM5ZYnvzsOUBzSGH4+T3EgrQ91KI=";
        //private readonly IOptionsSnapshot<DTDSettings> _dTDSettings;
        public CustomTokenAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            //_dTDSettings = dTDSettings;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Request.EnableBuffering();
            string bodyString;
            using (var reader = new StreamReader(
        Request.Body,
        encoding: Encoding.UTF8,
        detectEncodingFromByteOrderMarks: false,
        leaveOpen: true))
            {
                bodyString = await reader.ReadToEndAsync();
                Console.WriteLine("*****************");
                Console.WriteLine("CustomTokenAuthHandler:" + bodyString);
                Console.WriteLine("*****************");
                Request.Body.Position = 0;
            }
            await Task.Delay(1);

            //var authString = Request.Headers.Authorization.ToString();
            //var requestSchema = authString.Split(' ')[0];
            //var requestKeyId = authString.Split(' ')[1]?.Split(';')[0];
            //var requestSecrect = authString.Split(' ')[1]?.Split(';')[1];

            //// Signature
            //string signature;
            //using (var hmac = new HMACSHA256(Convert.FromBase64String(keySecrect)))
            //{
            //    signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(bodyString)));
            //}

            //if (CryptographicOperations.FixedTimeEquals(hashBytes, requestHmacFromHeader) != true)
            //{
            //    // Fail the request, hash mismatch
            //    return;
            //}

            //if (!Request.Headers.ContainsKey(Options.TokenHeaderName))
            //    return Task.FromResult(AuthenticateResult.Fail($"Missing Header For Token: {Options.TokenHeaderName}"));

            //var token = Request.Headers[Options.TokenHeaderName];

            //if (string.IsNullOrEmpty(token) || !token.Equals(_dTDSettings.Value.AuthToken))
            //    return Task.FromResult(AuthenticateResult.Fail($"{Options.TokenHeaderName} token is invalid"));

            var claims = Array.Empty<Claim>();
            var id = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(id);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
