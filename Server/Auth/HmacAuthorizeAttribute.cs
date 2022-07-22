using Microsoft.AspNetCore.Authorization;

namespace Server.Auth
{
    public class HmacAuthorizeAttribute : AuthorizeAttribute
    {
        public HmacAuthorizeAttribute() : base()
        {
            setAuthenticationSchemes();
        }

        public HmacAuthorizeAttribute(string policy) : base(policy)
        {
            setAuthenticationSchemes();
        }

        private void setAuthenticationSchemes()
        {
            AuthenticationSchemes = "HMACSHA256";
        }
    }
}