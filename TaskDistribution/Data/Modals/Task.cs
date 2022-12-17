namespace TaskDistribution.Data.Modals
{
    public class Task
    {
        public int TaskID { get; set; }
        public string? Task_NM { get; set; }
        public string? Task_DSC { get; set; }
        public int TaskDifficultTypeID { get; set; }
        public virtual TaskDifficultType? TaskDifficultType { get; set; }
        public  int UserID { get; set; }    
        public virtual User? User { get; set; }
        public bool IsDeleted_FL { get; set; }
    }
}
