using System.Reflection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Prometheus;

namespace Server.Cache
{
    public class TokenCache : ITokenCache
    {
        public PostEvictionDelegate? PostEvictionDelegate { set; get; }
        private ILogger<TokenCache> _logger;
        private IMemoryCache _cache;
        public TokenCache(ILogger<TokenCache> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
            PostEvictionDelegate = OnTokenExpired;
        }

        public async Task<string> FetchToken(CancellationToken cancellationToken)
        {
            string token;

                token = await _cache.GetOrCreateAsync("Auth0Token", async entry =>
                {
                    await Task.Delay(1);
                    var absoluteExpirationRelativeToNow =
                    TimeSpan.FromSeconds(10);

                    if (PostEvictionDelegate != null)
                    {
                        entry.AddExpirationToken(GetExpirationToken(absoluteExpirationRelativeToNow));
                        entry.RegisterPostEvictionCallback(PostEvictionDelegate);
                    }

                    entry.AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow.Add(TimeSpan.FromMilliseconds(2000));

                    return DateTime.Now.ToString();
                });
            

            return token;
        }

        private void OnTokenExpired(object key, object value, EvictionReason reason, object state)
        {
            
            _logger.LogInformation($"Cached token expired - caching new token at {DateTime.Now.ToString()}...");

            Task.Run(async () => await FetchToken(new CancellationToken())).Wait();
        }

        private static CancellationChangeToken GetExpirationToken(TimeSpan expiration)
        {
            var cancellationTokenSource = new CancellationTokenSource(expiration.Add(TimeSpan.FromMilliseconds(1000)));
            var expirationToken = new CancellationChangeToken(cancellationTokenSource.Token);
            return expirationToken;
        }
    }
}