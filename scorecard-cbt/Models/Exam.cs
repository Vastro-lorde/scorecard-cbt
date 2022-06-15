using System.ComponentModel.DataAnnotations;

namespace scorecard_cbt.Models
{
    public class Exam
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string ExamName { get; set; }
        [Required]
        public string Duration { get; set; }
    }
}
