using Microsoft.EntityFrameworkCore;

namespace TaskDistribution.Data.Modals
{
    public class TaskDistributionContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=TaskDistribution; Integrated Security=true");
        }
        public DbSet<Task> Tasks  => this.Set<Task>();
        public DbSet<TaskDifficultType> TaskDifficultTypes => this.Set<TaskDifficultType>();
        public DbSet<User> Users => this.Set<User>();
        public DbSet<UserRole> UserRoles => this.Set<UserRole>();
        public DbSet<TaskType> TaskTypes => this.Set<TaskType>();
    }
}
