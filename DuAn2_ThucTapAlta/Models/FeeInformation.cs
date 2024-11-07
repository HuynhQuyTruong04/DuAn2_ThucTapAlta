namespace DuAn2_ThucTapAlta.Models
{
    public class FeeInformation
    {
        public int Id { get; set; }
        public string FeeType { get; set; }
        public float FeeLevel { get; set; }
        public float Discount { get; set; }
        public string Note { get; set; }

        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public Student Student { get; set; }
        public Class Class { get; set; }
    }
}
