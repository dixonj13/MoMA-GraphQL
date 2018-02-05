using MoMAGraphQL.Data.Repositories;
using MoMAGraphQL.Models.Api;
using StackExchange.Redis.Extensions.Core;

namespace MoMAGraphQL.Data.Redis.Repositories
{
    public class ArtistCacheRepository : BaseCacheRepository<Artist>, IArtistRepository
    {
        public ArtistCacheRepository(ICacheClient cache) : base(cache, "artist") { }
    }
}
