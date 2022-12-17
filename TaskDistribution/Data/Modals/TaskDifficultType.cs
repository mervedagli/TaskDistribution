namespace TaskDistribution.Data.Modals
{
    public class TaskDifficultType
    {
        public int TaskDifficultTypeID { get; set; }
        public string? TaskDifficultType_NM { get; set; }
        public int TaskDifficultType_NO { get; set; }
        public bool IsDeleted_FL { get; set; }
        public List<Task>? Tasks { get; set; }
    }
}
