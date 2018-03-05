using GraphQLApi.Data.Repositories;
using GraphQLApi.Models.Api;
using StackExchange.Redis.Extensions.Core;

namespace GraphQLApi.Data.Redis.Repositories
{
    public class ArtistCache : BaseCache<Artist>, IArtistRepository
    {
        public ArtistCache(ICacheClient cache) : base(cache, "artist") { }
    }
}
