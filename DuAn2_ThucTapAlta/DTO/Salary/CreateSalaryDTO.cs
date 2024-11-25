namespace DuAn2_ThucTapAlta.DTO.Salary
{
    public class CreateSalaryDTO
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public float SalaryPerStudent { get; set; }
        public float Allowance { get; set; }
        public float TotalSalary { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
