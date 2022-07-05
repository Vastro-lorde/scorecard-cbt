using scorecard_cbt.ModelValidationHelper;
using System;
using System.ComponentModel.DataAnnotations;

namespace scorecard_cbt.DTOs
{
    public class ExamRegistrationDto
    {
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.TitleValidator)]
        public string Title { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CodeValidator)]
        public string ShortCode { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.DescriptionValidator)]
        public string Description { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public string CourseId { get; set; }
    }
}
