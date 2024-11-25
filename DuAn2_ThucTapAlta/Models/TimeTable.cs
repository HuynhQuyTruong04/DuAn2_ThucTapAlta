namespace DuAn2_ThucTapAlta.Models
{
    public class TimeTable
    {
        public int Id { get; set; }
        public DateTime StudyDate { get; set; }
        public TimeSpan StudyTime { get; set; }
        public bool IsActive { get; set; } = true;

        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public Class Class { get; set; }
        public Teacher Teacher { get; set; }
    }
}
