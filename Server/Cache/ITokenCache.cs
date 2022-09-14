using Microsoft.Extensions.Caching.Memory;

namespace Server.Cache
{
    public interface ITokenCache
    {
        PostEvictionDelegate? PostEvictionDelegate { set; }
        Task<string> FetchToken(CancellationToken cancellationToken);
    }
}
