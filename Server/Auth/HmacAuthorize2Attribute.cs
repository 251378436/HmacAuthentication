using Microsoft.AspNetCore.Authorization;

namespace Server.Auth
{
    public class HmacAuthorize2Attribute : AuthorizeAttribute
    {
        public HmacAuthorize2Attribute() : base()
        {
            setAuthenticationSchemes();
        }

        public HmacAuthorize2Attribute(string policy) : base(policy)
        {
            setAuthenticationSchemes();
        }

        private void setAuthenticationSchemes()
        {
            AuthenticationSchemes = "HMACSHA2562";
        }
    }
}