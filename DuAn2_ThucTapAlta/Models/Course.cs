namespace DuAn2_ThucTapAlta.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string NameCourse { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
