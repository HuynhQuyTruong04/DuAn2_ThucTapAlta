using DuAn2_ThucTapAlta.DTO.Enrollment;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Services
{
    public interface IEnrollmentService
    {
        Task<Enrollment> GetEnrollmentByIdAsync(int id);
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
        Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollments);
        Task<Enrollment> UpdateEnrollmentAsync(int id, UpdateEnrollmentDTO updateDto);
        Task<bool> DeactivateEnrollmentAsync(int id);
        Task<bool> ActivateEnrollmentAsync(int id);
        Task<IEnumerable<Enrollment>> GetInactiveEnrollmentsAsync();
    }
}
