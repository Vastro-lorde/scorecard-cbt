using scorecard_cbt.ModelValidationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scorecard_cbt.Models
{
    public class Exam : BaseEntity
    {
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.TitleValidator)]
        public string Title { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CodeValidator)]
        public string ShortCode { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.DescriptionValidator)]
        public string Description { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CreatedByValidator)]
        public string CreatedBy { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.UpdatedByValidator)]
        public string UpdatedBy { get; set; }  
        public bool Status { get; set; }
        
        [ForeignKey(nameof(Course))]
        public string CourseId { get; set; }

        public virtual IEnumerable<Question> ExamQuestions { get; set; }
    }
}
