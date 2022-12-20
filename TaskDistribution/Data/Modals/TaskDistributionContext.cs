using Microsoft.EntityFrameworkCore;

namespace TaskDistribution.Data.Modals
{
    public class TaskDistributionContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=TaskDistribution1; Integrated Security=true");
        }
        public DbSet<Task> Tasks  => this.Set<Task>();
        public DbSet<TaskDifficultType> TaskDifficultTypes => this.Set<TaskDifficultType>();
        public DbSet<User> Users => this.Set<User>();
        public DbSet<UserRole> UserRoles => this.Set<UserRole>();
        public DbSet<TaskType> TaskTypes => this.Set<TaskType>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDifficultType>().HasData(
                new TaskDifficultType
                {
                    TaskDifficultTypeID = 1,
                    TaskDifficultType_NM = "Kolay",
                    TaskDifficultType_NO = 1,
                    IsDeleted_FL=false
                },
                new TaskDifficultType
                {
                    TaskDifficultTypeID= 2,
                    TaskDifficultType_NM = "Orta",
                    TaskDifficultType_NO = 2,
                    IsDeleted_FL = false
                }, 
                new TaskDifficultType
                {
                    TaskDifficultTypeID=3,
                    TaskDifficultType_NM = "Zor",
                    TaskDifficultType_NO = 3,
                    IsDeleted_FL = false
                }
            );

            modelBuilder.Entity<TaskType>().HasData(
               new TaskType
               {
                   TaskTypeID = 1,
                   TaskType_NM = "BugFix",
                   TaskType_NO = 1,
                   IsDeleted_FL = false
               },
               new TaskType
               {
                   TaskTypeID = 2,
                   TaskType_NM = "Test",
                   TaskType_NO = 2,
                   IsDeleted_FL = false
               },
                new TaskType
                {
                    TaskTypeID = 3,
                    TaskType_NM = "Geliştirme",
                    TaskType_NO = 3,
                    IsDeleted_FL = false
                },
                 new TaskType
                 {
                     TaskTypeID = 4,
                     TaskType_NM = "Veritabanı İşlemleri",
                     TaskType_NO = 4,
                     IsDeleted_FL = false
                 },
               new TaskType
               {
                   TaskTypeID = 5,
                   TaskType_NM = "Frontend Geliştirme",
                   TaskType_NO = 5,
                   IsDeleted_FL = false
               },
                new TaskType
                {
                    TaskTypeID = 6,
                    TaskType_NM = "Refactor",
                    TaskType_NO = 6,
                    IsDeleted_FL = false
                },
                   new TaskType
                   {
                       TaskTypeID = 7,
                       TaskType_NM = "Güvenlik taraması",
                       TaskType_NO = 7,
                       IsDeleted_FL = false
                   },
                new TaskType
                {
                    TaskTypeID = 8,
                    TaskType_NM = "Analiz",
                    TaskType_NO = 8,
                    IsDeleted_FL = false
                }
           );

            modelBuilder.Entity<UserRole>().HasData(
               new UserRole { UserRoleID = 1, UserRole_NM = "Software Analyst",  IsDeleted_FL = false },
               new UserRole { UserRoleID = 2, UserRole_NM = "User",  IsDeleted_FL = false },
               new UserRole { UserRoleID = 3, UserRole_NM = "Software Manager", IsDeleted_FL = false }

           );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1,  User_NM= "Cansu",   Password_TXT="1234", UserRoleID=1, IsDeleted_FL=false},
                new User { UserId = 2,  User_NM= "Merve",   Password_TXT="1234", UserRoleID=2,  IsDeleted_FL=false },
                new User { UserId = 3,  User_NM= "Yasemin", Password_TXT="1234", UserRoleID=3,  IsDeleted_FL=false },
                new User { UserId = 4,  User_NM= "Betül",   Password_TXT="1234", UserRoleID=2,  IsDeleted_FL=false },
                new User { UserId = 5,  User_NM= "Murat",   Password_TXT="1234", UserRoleID=2,  IsDeleted_FL=false },
                new User { UserId = 6,  User_NM= "Zeynep",  Password_TXT="1234", UserRoleID=2,  IsDeleted_FL=false },
                new User { UserId = 7,  User_NM= "Dilan",   Password_TXT="1234", UserRoleID=2,  IsDeleted_FL=false },
                new User { UserId = 8,  User_NM= "Aysu",    Password_TXT="1234", UserRoleID=2,  IsDeleted_FL=false },
                new User { UserId = 9,  User_NM= "Melisa",  Password_TXT="1234", UserRoleID=2,  IsDeleted_FL=false },
                new User { UserId = 10,  User_NM= "Hilal",  Password_TXT="1234", UserRoleID=2, IsDeleted_FL = false }
            );
        }
    }
}
