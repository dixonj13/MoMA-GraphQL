using MoMAGraphQL.Data.Repositories;
using MoMAGraphQL.Models.Api;
using StackExchange.Redis.Extensions.Core;

namespace MoMAGraphQL.Data.Redis.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ICacheClient cache) : base(cache, "artist") { }
    }
}
