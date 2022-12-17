using TaskDistribution.Data.Modals;

namespace TaskDistribution.Repositories
{
    public class TaskDifficultTypeRepository : GenericRepository<TaskDifficultType>, ITaskDifficultTypeRepository
    {
        public TaskDifficultTypeRepository(TaskDistributionContext dbContext) : base(dbContext)
        {
        }
    }
}
