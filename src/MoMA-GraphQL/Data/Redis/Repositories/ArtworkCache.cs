using MoMAGraphQL.Data.Repositories;
using MoMAGraphQL.Models.Api;
using StackExchange.Redis.Extensions.Core;

namespace MoMAGraphQL.Data.Redis.Repositories
{
    public class ArtworkCache : BaseCache<Artwork>, IArtworkRepository
    {
        public ArtworkCache(ICacheClient cache) : base(cache, "artwork") { }
    }
}
