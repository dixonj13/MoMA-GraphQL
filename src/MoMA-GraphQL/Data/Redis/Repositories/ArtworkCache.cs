using GraphQLApi.Data.Repositories;
using GraphQLApi.Models.Api;
using StackExchange.Redis.Extensions.Core;

namespace GraphQLApi.Data.Redis.Repositories
{
    public class ArtworkCache : BaseCache<Artwork>, IArtworkRepository
    {
        public ArtworkCache(ICacheClient cache) : base(cache, "artwork") { }
    }
}
