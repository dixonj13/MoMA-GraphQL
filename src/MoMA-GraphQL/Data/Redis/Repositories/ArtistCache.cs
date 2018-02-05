using MoMAGraphQL.Data.Repositories;
using MoMAGraphQL.Models.Api;
using StackExchange.Redis.Extensions.Core;

namespace MoMAGraphQL.Data.Redis.Repositories
{
    public class ArtistCache : BaseCache<Artist>, IArtistRepository
    {
        public ArtistCache(ICacheClient cache) : base(cache, "artist") { }
    }
}
