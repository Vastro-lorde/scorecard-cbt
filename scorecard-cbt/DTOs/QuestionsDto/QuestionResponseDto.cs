﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scorecard_cbt.DTOs
{
    public class QuestionResponseDto
    {
        public string QuestionId { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }
        public char AnswerOption { get; set; }
        public string ExamId { get; set; }
    }
}
