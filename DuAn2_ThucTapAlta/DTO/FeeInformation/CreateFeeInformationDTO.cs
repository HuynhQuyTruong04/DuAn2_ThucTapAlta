namespace DuAn2_ThucTapAlta.DTO.FeeInformation
{
    public class CreateFeeInformationDTO
    {
        public int Id { get; set; }
        public string FeeType { get; set; }
        public float FeeLevel { get; set; }
        public float Discount { get; set; }
        public string Note { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
    }
}
