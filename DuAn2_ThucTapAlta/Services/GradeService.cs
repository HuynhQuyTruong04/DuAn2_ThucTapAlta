using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.Grade;
using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAn2_ThucTapAlta.Services
{
    public class GradeService : IGradeService
    {
        private readonly ApplicationDBContext _context;

        public GradeService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Grade> GetGradeByIdAsync(int id)
        {
            return await _context.Grades.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Grade>> GetAllGradesAsync()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade> CreateGradeAsync(Grade grades)
        {
            await _context.Grades.AddAsync(grades);
            await _context.SaveChangesAsync();
            return grades;
        }

        public async Task<Grade> UpdateGradeAsync(int id, UpdateGradeDTO updateDto)
        {
            var existingGrade = await _context.Grades.FirstOrDefaultAsync(x => x.Id == id);

            if (existingGrade == null)
            {
                return null;
            }

            existingGrade.Score = updateDto.Score;
            existingGrade.GradeType = updateDto.GradeType;
            existingGrade.StudentId = updateDto.StudentId;
            existingGrade.ClassId = updateDto.ClassId;

            await _context.SaveChangesAsync();
            return existingGrade;
        }

        public async Task<bool> DeactivateGradeAsync(int id)
        {
            var grades = await _context.Grades.FirstOrDefaultAsync(x => x.Id == id);
            if (grades == null)
            {
                return false;
            }

            grades.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateGradeAsync(int id)
        {
            var grades = await _context.Grades.FirstOrDefaultAsync(x => x.Id == id);
            if (grades == null || grades.IsActive)
            {
                return false;
            }

            grades.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Grade>> GetInactiveGradesAsync()
        {
            return await _context.Grades
                                 .Where(f => !f.IsActive)
                                 .ToListAsync();
        }
    }
}
