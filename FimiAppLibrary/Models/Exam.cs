﻿namespace FimiAppLibrary.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ExamTypeId { get; set; }
    }
}
