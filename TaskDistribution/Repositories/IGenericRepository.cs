using System.Linq.Expressions;

namespace TaskDistribution.Repositories
{
    public interface IGenericRepository<TEntity> 
    {
        Task<TEntity> Find(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Remove(TEntity entity);
        Task Update(TEntity entity);
        Task<IEnumerable<TEntity>> TList(string p,string? c=null);
        Task<TEntity?> GetByFilter(Expression<Func<TEntity, bool>> filter, string? c = null);
    }
}
