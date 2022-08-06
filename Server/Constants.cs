using Server.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        public static JsonSerializerOptions DefaultJsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumMemberConverter(new UnderscoreCaseNamingPolicy()) }
        };
    }
}
