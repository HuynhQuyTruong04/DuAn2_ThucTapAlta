using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.Subject;
using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAn2_ThucTapAlta.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDBContext _context;

        public SubjectService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> UpdateSubjectAsync(int id, UpdateSubjectDTO updateDto)
        {
            var existingSubjects = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);

            if (existingSubjects == null)
            {
                return null;
            }

            existingSubjects.SubjectName = updateDto.SubjectName;
            existingSubjects.ClassId = updateDto.ClassId;

            await _context.SaveChangesAsync();
            return existingSubjects;
        }

        public async Task<bool> DeactivateSubjectAsync(int id)
        {
            var subjects = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            if (subjects == null)
            {
                return false;
            }

            subjects.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateSubjectAsync(int id)
        {
            var subjects = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            if (subjects == null || subjects.IsActive)
            {
                return false;
            }

            subjects.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Subject>> GetInactiveSubjectsAsync()
        {
            return await _context.Subjects
                                 .Where(f => !f.IsActive)
                                 .ToListAsync();
        }
    }
}
