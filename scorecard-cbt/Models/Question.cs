using scorecard_cbt.ModelValidationHelper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scorecard_cbt.Models
{

    public class Question : BaseEntity
    {
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.DescriptionValidator)]
        public string Description { get; set; }
        public virtual ICollection<Option> Options { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CreatedByValidator)]
        public string CreatedBy { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.UpdatedByValidator)]
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }
        public short AnswerOptionId { get; set; }//OptionId
        public virtual Exam Exam { get; set; }
    }
}
