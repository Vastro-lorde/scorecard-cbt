using scorecard_cbt.ModelValidationHelper;
using System.ComponentModel.DataAnnotations;

namespace scorecard_cbt.DTOs
{
    public class UpdateQuestionDto
    {
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.DescriptionValidator)]
        public string Description { get; set; }
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }
        public short AnswerOptionId { get; set; }//OptionId
    }
}
