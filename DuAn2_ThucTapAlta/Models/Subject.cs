﻿namespace DuAn2_ThucTapAlta.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public bool IsActive { get; set; } = true;
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
