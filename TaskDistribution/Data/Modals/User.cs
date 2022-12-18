namespace TaskDistribution.Data.Modals
{
    public class User
    {
        public int UserId { get; set; } 
        public string? User_NM { get; set; }
        public string? Password_TXT { get; set; }
        public int? UserRoleID { get; set; }
        public virtual UserRole? UserRole { get; set; }
        public bool IsDeleted_FL { get; set; }
        public List<Task>? Tasks { get; set; }   
    }
}
