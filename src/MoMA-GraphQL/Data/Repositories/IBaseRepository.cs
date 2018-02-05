using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoMAGraphQL.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);

        Task<ICollection<TEntity>> Get(IEnumerable<int> ids);

        Task<ICollection<TEntity>> GetAll();
    }
}
