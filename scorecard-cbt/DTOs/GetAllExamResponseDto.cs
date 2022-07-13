using scorecard_cbt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace scorecard_cbt.DTOs
{
    public class GetAllExamResponseDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortCode { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }

        [ForeignKey(nameof(Course))]
        public string CourseId { get; set; }

        public virtual IEnumerable<Question> ExamQuestions { get; set; }
    }
}
