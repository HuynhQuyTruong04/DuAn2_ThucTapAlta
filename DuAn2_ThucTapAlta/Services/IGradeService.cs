using DuAn2_ThucTapAlta.DTO.Grade;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Services
{
    public interface IGradeService
    {
        Task<Grade> GetGradeByIdAsync(int id);
        Task<IEnumerable<Grade>> GetAllGradesAsync();
        Task<Grade> CreateGradeAsync(Grade grades);
        Task<Grade> UpdateGradeAsync(int id, UpdateGradeDTO updateDto);
        Task<bool> DeactivateGradeAsync(int id);
        Task<bool> ActivateGradeAsync(int id);
        Task<IEnumerable<Grade>> GetInactiveGradesAsync();
    }
}
