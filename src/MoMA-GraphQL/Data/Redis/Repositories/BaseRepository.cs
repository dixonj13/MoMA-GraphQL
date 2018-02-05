using MoMAGraphQL.Data.Repositories;
using StackExchange.Redis.Extensions.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoMAGraphQL.Data.Redis.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected string hashKey;
        protected ICacheClient cache;

        protected BaseRepository(ICacheClient cache, string hashKey)
        {
            this.hashKey = hashKey;
            this.cache = cache;
        }

        public Task<TEntity> Get(int id)
        {
            return cache.HashGetAsync<TEntity>(hashKey, id.ToString());
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            var artists = await cache.HashGetAllAsync<TEntity>(hashKey);
            return artists.Values;
        }
    }
}
