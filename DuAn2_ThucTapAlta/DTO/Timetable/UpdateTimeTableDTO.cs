namespace DuAn2_ThucTapAlta.DTO.Timetable
{
    public class UpdateTimeTableDTO
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public DateTime StudyDate { get; set; }
        public TimeSpan StudyTime { get; set; }
    }
}
