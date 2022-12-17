using TaskDistribution.Data.Modals;

namespace TaskDistribution.Repositories
{
    public class TaskRepository:GenericRepository<TaskDistribution.Data.Modals.Task>,ITaskRepository
    {
        public TaskRepository(TaskDistributionContext dbContext):base(dbContext)
        {

        }
    }
}
