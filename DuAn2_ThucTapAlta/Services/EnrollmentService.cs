using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.Enrollment;
using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAn2_ThucTapAlta.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly ApplicationDBContext _context;

        public EnrollmentService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            return await _context.Enrollments.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollments)
        {
            await _context.Enrollments.AddAsync(enrollments);
            await _context.SaveChangesAsync();
            return enrollments;
        }

        public async Task<Enrollment> UpdateEnrollmentAsync(int id, UpdateEnrollmentDTO updateDto)
        {
            var existingEnrollment = await _context.Enrollments.FirstOrDefaultAsync(x => x.Id == id);

            if (existingEnrollment == null)
            {
                return null;
            }

            existingEnrollment.EnrollmentDate = updateDto.EnrollmentDate;
            existingEnrollment.Status = updateDto.Status;
            existingEnrollment.StudentId = updateDto.StudentId;
            existingEnrollment.ClassId = updateDto.ClassId;
            existingEnrollment.CourseId = updateDto.CourseId;

            await _context.SaveChangesAsync();
            return existingEnrollment;
        }

        public async Task<bool> DeactivateEnrollmentAsync(int id)
        {
            var enrollments = await _context.Enrollments.FirstOrDefaultAsync(x => x.Id == id);
            if (enrollments == null)
            {
                return false;
            }

            enrollments.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateEnrollmentAsync(int id)
        {
            var enrollments = await _context.Enrollments.FirstOrDefaultAsync(x => x.Id == id);
            if (enrollments == null || enrollments.IsActive)
            {
                return false;
            }

            enrollments.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Enrollment>> GetInactiveEnrollmentsAsync()
        {
            return await _context.Enrollments
                                 .Where(f => !f.IsActive)
                                 .ToListAsync();
        }
    }
}
