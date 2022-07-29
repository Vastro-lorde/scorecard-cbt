using scorecard_cbt.ModelValidationHelper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scorecard_cbt.Models
{
    public class Result : BaseEntity
    {
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CreatedByValidator)]
        public string DevName { get; set; }
        [Required]
        public string DevSquad { get; set; }
        [Required]
        public short ExamScore { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Remark { get; set; }
        [Required]
        [ForeignKey(nameof(Exam))]
        public string ExamId { get; set; }
    }
}
