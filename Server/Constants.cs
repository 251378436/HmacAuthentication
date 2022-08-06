using System.Diagnostics.CodeAnalysis;

namespace Server
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public static class Auth
        {
            public const string HmacSha256OrJwtBearer = "HmacSha256OrJwtBearer";
            public const string JwtBearer = "bearer";
            public const string HmacSha256 = "hmac_sha256";
            public const string HmacSha2562 = "hmac_sha2562";
        }
    }
}
