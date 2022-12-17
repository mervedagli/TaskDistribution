using TaskDistribution.Data.Modals;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskDistribution.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TaskDistributionContext _dbContext;

        public GenericRepository(TaskDistributionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Find(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();  
        }

        public async System.Threading.Tasks.Task Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<TEntity>> TList(string p, string? c=null)
        {
            if (c!=null)
            {
                return await _dbContext.Set<TEntity>().Include(p).Include(c).ToListAsync();
            }
            else
            {

                return await _dbContext.Set<TEntity>().Include(p).ToListAsync();
            }
        }
    }
}
