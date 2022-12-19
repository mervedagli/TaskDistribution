namespace TaskDistribution.Repositories
{
    public interface ITaskRepository:IGenericRepository<TaskDistribution.Data.Modals.Task>
    {
        Task<IEnumerable<TaskDistribution.Data.Modals.Task>> Assignment();    
    }
}
