using scorecard_cbt.ModelValidationHelper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scorecard_cbt.Models
{

    public class Question : BaseEntity
    {
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Option> Options { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CreatedByValidator)]
        public string CreatedBy { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.UpdatedByValidator)]
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }
        public char AnswerOption { get; set; }
        [ForeignKey(nameof(Exam))]
        public string ExamId { get; set; }
    }
}
