using TaskDistribution.Data.Modals;

namespace TaskDistribution.Repositories
{
    public class LoginRepository : GenericRepository<User>, ILoginRepository
    {
        public LoginRepository(TaskDistributionContext dbContext) : base(dbContext)
        {

        }
    }
}
