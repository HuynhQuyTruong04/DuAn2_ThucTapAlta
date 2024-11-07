namespace DuAn2_ThucTapAlta.Models
{
    public class Leave
    {
        public int Id { get; set; } 
        public string LeaveName { get; set; }
        public string Reason { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
