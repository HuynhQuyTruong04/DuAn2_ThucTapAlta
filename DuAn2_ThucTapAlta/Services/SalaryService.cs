using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.Salary;
using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAn2_ThucTapAlta.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ApplicationDBContext _context;

        public SalaryService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Salary> GetSalaryByIdAsync(int id)
        {
            return await _context.Salaries.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Salary>> GetAllSalariesAsync()
        {
            return await _context.Salaries.ToListAsync();
        }

        public async Task<Salary> CreateSalaryAsync(Salary salaries)
        {
            await _context.Salaries.AddAsync(salaries);
            await _context.SaveChangesAsync();
            return salaries;
        }

        public async Task<Salary> UpdateSalaryAsync(int id, UpdateSalaryDTO updateDto)
        {
            var existingSalary = await _context.Salaries.FirstOrDefaultAsync(x => x.Id == id);

            if (existingSalary == null)
            {
                return null;
            }

            existingSalary.SalaryPerStudent = updateDto.SalaryPerStudent;
            existingSalary.Allowance = updateDto.Allowance;
            existingSalary.TotalSalary = updateDto.TotalSalary;
            existingSalary.Note = updateDto.Note;
            existingSalary.CreateDate = updateDto.CreateDate;
            existingSalary.UpdateDate = updateDto.UpdateDate;
            existingSalary.TeacherId = updateDto.TeacherId;

            await _context.SaveChangesAsync();
            return existingSalary;
        }

        public async Task<bool> DeactivateSalaryAsync(int id)
        {
            var salaries = await _context.Salaries.FirstOrDefaultAsync(x => x.Id == id);
            if (salaries == null)
            {
                return false;
            }

            salaries.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateSalaryAsync(int id)
        {
            var salaries = await _context.Salaries.FirstOrDefaultAsync(x => x.Id == id);
            if (salaries == null || salaries.IsActive)
            {
                return false;
            }

            salaries.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Salary>> GetInactiveSalariesAsync()
        {
            return await _context.Salaries
                                 .Where(f => !f.IsActive)
                                 .ToListAsync();
        }
    }
}
