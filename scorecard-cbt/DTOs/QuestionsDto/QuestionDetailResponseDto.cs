using scorecard_cbt.Models;
using System.Collections.Generic;

namespace scorecard_cbt.DTOs
{
    public class QuestionDetailResponseDto
    {
        public string Description { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public char AnswerOption { get; set; }
        public virtual Exam Exam { get; set; }
    }
}