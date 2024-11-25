using DuAn2_ThucTapAlta.DTO.Teacher;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Services
{
    public interface ITeacherService
    {
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> CreateTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateTeacherAsync(int id, UpdateTeacherDTO updateDto);
        Task<bool> DeactivateTeacherAsync(int id);
        Task<bool> ActivateTeacherAsync(int id);
        Task<IEnumerable<Teacher>> GetInactiveTeachersAsync();
    }
}
