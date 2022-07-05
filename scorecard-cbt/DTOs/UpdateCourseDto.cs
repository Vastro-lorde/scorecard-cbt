using scorecard_cbt.ModelValidationHelper;
using System.ComponentModel.DataAnnotations;

namespace scorecard_cbt.DTOs
{
    public class UpdateCourseDto
    {
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.TitleValidator)]
        public string Title { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.DescriptionValidator)]
        public string Description { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.OverviewValidator)]
        public string Overview { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CodeValidator)]
        public string Code { get; set; }
    }
}
