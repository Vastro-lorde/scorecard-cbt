namespace scorecard_cbt.Models
{
    public class Option : BaseEntity
    {
        public string Answer { get; set; }
        public string option { get; set; }
        public virtual Question Question { get; set; }
    }
}