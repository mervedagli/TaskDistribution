namespace TaskDistribution.Data.Modals
{
    public class UserRole
    {
        public int UserRoleID { get; set; }
        public string? UserRole_NM { get; set; }
        public bool IsDeleted_FL { get; set; }
        public List<User>? Users { get; set; }
    }
}
