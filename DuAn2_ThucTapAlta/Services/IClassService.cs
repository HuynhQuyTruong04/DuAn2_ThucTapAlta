using DuAn2_ThucTapAlta.DTO.Class;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Services
{
    public interface IClassService
    {
        Task<Class> GetClassByIdAsync(int id);
        Task<IEnumerable<Class>> GetAllClassesAsync();
        Task<Class> CreateClassAsync(Class classes);
        Task<Class> UpdateClassAsync(int id, UpdateClassDTO updateDto);
        Task<bool> DeactivateClassAsync(int id);
        Task<bool> ActivateClassAsync(int id);
        Task<IEnumerable<Class>> GetInactiveClassesAsync();
    }
}
