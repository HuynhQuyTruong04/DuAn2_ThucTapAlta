namespace DuAn2_ThucTapAlta.DTO.Class
{
    public class CreateClassDTO
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string NameClass { get; set; }
        public string Description { get; set; }
        public int MaxStudent { get; set; }
        public float TuitionFee { get; set; }
        public string Image { get; set; }
        public int AcademicYear { get; set; }
    }
}
