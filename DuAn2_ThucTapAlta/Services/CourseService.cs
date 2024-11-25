using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.Course;
using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DuAn2_ThucTapAlta.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDBContext _context;

        public CourseService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(s => s.Id == id && s.IsActive);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.Where(u => u.IsActive).ToListAsync();
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateCourseAsync(int id, UpdateCourseDTO updateDto)
        {
            var existingCourse = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingCourse == null)
            {
                return null;
            }

            existingCourse.NameCourse = updateDto.NameCourse;
            existingCourse.Description = updateDto.Description;
            existingCourse.CreateDate = updateDto.CreateDate;
            existingCourse.UpdateDate = updateDto.UpdateDate;

            await _context.SaveChangesAsync();
            return existingCourse;
        }
        public async Task<bool> DeactivateCourseAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (course == null)
            {
                return false;
            }

            course.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateCourseAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course == null || course.IsActive)
            {
                return false;
            }

            course.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Course>> GetInactiveCoursesAsync()
        {
            return await _context.Courses
                                 .Where(f => !f.IsActive)
                                 .ToListAsync();
        }
    }
}
