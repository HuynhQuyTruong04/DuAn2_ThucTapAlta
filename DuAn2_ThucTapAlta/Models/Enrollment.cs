namespace DuAn2_ThucTapAlta.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }

        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Class Class { get; set; }
        public Course Course { get; set; }
    }
}
