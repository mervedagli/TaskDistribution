using TaskDistribution.Data.Modals;

namespace TaskDistribution.Repositories
{
    public class TaskTypeRepository : GenericRepository<TaskType>, ITaskTypeRepository
    {
        public TaskTypeRepository(TaskDistributionContext dbContext) : base(dbContext)
        {

        }
    }
}