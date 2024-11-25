namespace DuAn2_ThucTapAlta.DTO.Enrollment
{
    public class EnrollmentDTO
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int CourseId { get; set; }
    }
}
