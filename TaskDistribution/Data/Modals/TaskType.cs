namespace TaskDistribution.Data.Modals
{
    public class TaskType
    {
        public int TaskTypeID { get; set; }
        public string? TaskType_NM { get; set; }
        public int TaskType_NO { get; set; }
        public bool IsDeleted_FL { get; set; }
        public List<Task>? Tasks { get; set; }
    }
}
