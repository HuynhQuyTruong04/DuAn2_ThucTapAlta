namespace DuAn2_ThucTapAlta.DTO.Grade
{
    public class CreateGradeDTO
    {
        public int Id { get; set; }
        public float Score { get; set; }
        public string GradeType { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
    }
}
