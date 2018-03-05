using GraphQLApi.Data.Repositories;
using StackExchange.Redis.Extensions.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLApi.Data.Redis.Repositories
{
    public abstract class BaseCache<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected string hashKey;
        protected ICacheClient cache;

        protected BaseCache(ICacheClient cache, string hashKey)
        {
            this.hashKey = hashKey;
            this.cache = cache;
        }

        public Task<TEntity> Get(int id)
        {
            return cache.HashGetAsync<TEntity>(hashKey, id.ToString());
        }

        public async Task<ICollection<TEntity>> Get(IEnumerable<int> ids)
        {
            var entity = await cache.HashGetAsync<TEntity>(hashKey, ids.Select(id => id.ToString()));
            return entity.Values;
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            var entity = await cache.HashGetAllAsync<TEntity>(hashKey);
            return entity.Values;
        }
    }
}
