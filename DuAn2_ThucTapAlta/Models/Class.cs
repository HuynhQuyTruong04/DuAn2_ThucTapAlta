namespace DuAn2_ThucTapAlta.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string NameClass { get; set; }
        public string Description { get; set; }
        public int MaxStudent {  get; set; }
        public float TuitionFee { get; set; }
        public string Image { get; set; }
        public int AcademicYear { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<FeeInformation> FeeInformations { get; set; }
        public ICollection<TimeTable> TimeTables { get; set; }
    }
}
