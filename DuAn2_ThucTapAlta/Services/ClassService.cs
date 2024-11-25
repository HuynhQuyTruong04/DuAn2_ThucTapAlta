using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.Class;
using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAn2_ThucTapAlta.Services
{
    public class ClassService : IClassService
    {
        private readonly ApplicationDBContext _context;

        public ClassService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Class> GetClassByIdAsync(int id)
        {
            return await _context.Classes.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Class>> GetAllClassesAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> CreateClassAsync(Class classes)
        {
            await _context.Classes.AddAsync(classes);
            await _context.SaveChangesAsync();
            return classes;
        }

        public async Task<Class> UpdateClassAsync(int id, UpdateClassDTO updateDto)
        {
            var existingClass = await _context.Classes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingClass == null)
            {
                return null;
            }

            existingClass.TeacherId = updateDto.TeacherId;
            existingClass.NameClass = updateDto.NameClass;
            existingClass.Description = updateDto.Description;
            existingClass.MaxStudent = updateDto.MaxStudent;
            existingClass.TuitionFee = updateDto.TuitionFee;
            existingClass.Image = updateDto.Image;
            existingClass.AcademicYear = updateDto.AcademicYear;

            await _context.SaveChangesAsync();
            return existingClass;
        }

        public async Task<bool> DeactivateClassAsync(int id)
        {
            var classes = await _context.Classes.FirstOrDefaultAsync(x => x.Id == id);
            if (classes == null)
            {
                return false;
            }

            classes.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateClassAsync(int id)
        {
            var classes = await _context.Classes.FirstOrDefaultAsync(x => x.Id == id);
            if (classes == null || classes.IsActive)
            {
                return false;
            }

            classes.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Class>> GetInactiveClassesAsync()
        {
            return await _context.Classes
                                 .Where(f => !f.IsActive)
                                 .ToListAsync();
        }
    }
}
