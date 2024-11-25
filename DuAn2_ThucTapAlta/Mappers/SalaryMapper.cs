using DuAn2_ThucTapAlta.DTO.Salary;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Mappers
{
    public static class SalaryMapper
    {
        public static SalaryDTO ToSalaryDTO(this Salary salaryModel)
        { 
            return new SalaryDTO
            {
                Id = salaryModel.Id,
                SalaryPerStudent = salaryModel.SalaryPerStudent,
                Allowance = salaryModel.Allowance,
                TotalSalary = salaryModel.TotalSalary,
                Note = salaryModel.Note,
                CreateDate = salaryModel.CreateDate,
                UpdateDate = salaryModel.UpdateDate,
                TeacherId = salaryModel.TeacherId
            };
        }
        public static Salary ToSalaryFromCreateDTO(this CreateSalaryDTO salaryDto)
        {
            return new Salary
            {
                Id = salaryDto.Id,
                SalaryPerStudent = salaryDto.SalaryPerStudent,
                Allowance = salaryDto.Allowance,
                TotalSalary = salaryDto.TotalSalary,
                Note = salaryDto.Note,
                CreateDate = salaryDto.CreateDate,
                UpdateDate = salaryDto.UpdateDate,
                TeacherId = salaryDto.TeacherId
            };
        }
    }
}
