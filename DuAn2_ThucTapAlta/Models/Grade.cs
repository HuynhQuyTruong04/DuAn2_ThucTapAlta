namespace DuAn2_ThucTapAlta.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public float Score { get; set; }
        public string GradeType { get; set; }

        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public Student Student { get; set; }
    }
}
