using System.ComponentModel.DataAnnotations;

namespace scorecard_cbt.DTOs
{
    public class QuestionRequestDto
    {
        [Required]
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }
        public short AnswerOptionId { get; set; }
    }
}
