using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.Teacher;
using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAn2_ThucTapAlta.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDBContext _context;

        public TeacherService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> UpdateTeacherAsync(int id, UpdateTeacherDTO updateDto)
        {
            var existingTeacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTeacher == null)
            {
                return null;
            }

            existingTeacher.UserId = updateDto.UserId;
            existingTeacher.FirstName = updateDto.FirstName;
            existingTeacher.LastName = updateDto.LastName;
            existingTeacher.Gender = updateDto.Gender;
            existingTeacher.Birthday = updateDto.Birthday;
            existingTeacher.Phone = updateDto.Phone;
            existingTeacher.Email = updateDto.Email;
            existingTeacher.Address = updateDto.Address;
            existingTeacher.SubjectSpecialization = updateDto.SubjectSpecialization;
            existingTeacher.UpdateDate = updateDto.UpdateDate;

            await _context.SaveChangesAsync();
            return existingTeacher;
        }

        public async Task<bool> DeactivateTeacherAsync(int id)
        {
            var teachers = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if (teachers == null)
            {
                return false;
            }

            teachers.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateTeacherAsync(int id)
        {
            var teachers = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if (teachers == null || teachers.IsActive)
            {
                return false;
            }

            teachers.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Teacher>> GetInactiveTeachersAsync()
        {
            return await _context.Teachers
                                 .Where(f => !f.IsActive)
                                 .ToListAsync();
        }
    }
}
