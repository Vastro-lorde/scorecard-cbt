using System;

namespace scorecard_cbt.DTOs
{
    public class ExamDetailResponseDto
    {
        public string Title { get; set; }
        public string ShortCode { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public bool Status { get; set; }
    }
}
