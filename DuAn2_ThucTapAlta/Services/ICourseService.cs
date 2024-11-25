using DuAn2_ThucTapAlta.DTO.Course;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Services
{
    public interface ICourseService
    {
        Task<Course> GetCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(int id, UpdateCourseDTO updateDto);
        Task<bool> DeactivateCourseAsync(int id);
        Task<bool> ActivateCourseAsync(int id);
        Task<IEnumerable<Course>> GetInactiveCoursesAsync();
    }
}
