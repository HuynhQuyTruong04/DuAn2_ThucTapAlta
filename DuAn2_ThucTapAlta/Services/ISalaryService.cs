using DuAn2_ThucTapAlta.DTO.Salary;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Services
{
    public interface ISalaryService
    {
        Task<Salary> GetSalaryByIdAsync(int id);
        Task<IEnumerable<Salary>> GetAllSalariesAsync();
        Task<Salary> CreateSalaryAsync(Salary classes);
        Task<Salary> UpdateSalaryAsync(int id, UpdateSalaryDTO updateDto);
        Task<bool> DeactivateSalaryAsync(int id);
        Task<bool> ActivateSalaryAsync(int id);
        Task<IEnumerable<Salary>> GetInactiveSalariesAsync();
    }
}
