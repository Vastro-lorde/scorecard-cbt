namespace scorecard_cbt.DTOs
{
    public class GetAllQuestionResponseDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }
        public char AnswerOption { get; set; }
        public string ExamId { get; set; }
    }
}
