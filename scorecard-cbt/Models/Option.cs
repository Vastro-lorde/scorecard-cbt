namespace scorecard_cbt.Models
{
    public class Option : BaseEntity
    {
        public string Answer { get; set; }
        public virtual Question Question { get; set; }
    }
}