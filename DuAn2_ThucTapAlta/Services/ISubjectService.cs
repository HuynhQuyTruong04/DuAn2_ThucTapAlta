using DuAn2_ThucTapAlta.DTO.Subject;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Services
{
    public interface ISubjectService
    {
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<Subject> CreateSubjectAsync(Subject subjects);
        Task<Subject> UpdateSubjectAsync(int id, UpdateSubjectDTO updateDto);
        Task<bool> DeactivateSubjectAsync(int id);
        Task<bool> ActivateSubjectAsync(int id);
        Task<IEnumerable<Subject>> GetInactiveSubjectsAsync();
    }
}
