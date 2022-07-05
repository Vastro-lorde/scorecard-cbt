using System;

namespace scorecard_cbt.DTOs
{
    public class ExamResponseDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortCode { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public string CourseId { get; set; }
    }
}
