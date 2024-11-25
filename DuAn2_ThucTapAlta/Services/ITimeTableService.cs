using DuAn2_ThucTapAlta.DTO.Timetable;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Services
{
    public interface ITimeTableService
    {
        Task<TimeTable> GetTimeTableByIdAsync(int id);
        Task<IEnumerable<TimeTable>> GetAllTimeTablesAsync();
        Task<TimeTable> CreateTimeTableAsync(TimeTable timetables);
        Task<TimeTable> UpdateTimeTableAsync(int id, UpdateTimeTableDTO updateDto);
        Task<bool> DeactivateTimeTableAsync(int id);
        Task<bool> ActivateTimeTableAsync(int id);
        Task<IEnumerable<TimeTable>> GetInactiveTimeTablesAsync();
    }
}
