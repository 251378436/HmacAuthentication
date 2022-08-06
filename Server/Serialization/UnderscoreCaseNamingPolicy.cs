using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Server.Serialization
{
    [ExcludeFromCodeCoverage]
    public class UnderscoreCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return string.Concat(name.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString())).ToLower();
        }
    }
}
