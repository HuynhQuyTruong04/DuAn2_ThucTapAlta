using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.Timetable;
using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAn2_ThucTapAlta.Services
{
    public class TimeTableService : ITimeTableService
    {
        private readonly ApplicationDBContext _context;

        public TimeTableService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TimeTable> GetTimeTableByIdAsync(int id)
        {
            return await _context.TimeTables.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<TimeTable>> GetAllTimeTablesAsync()
        {
            return await _context.TimeTables.ToListAsync();
        }

        public async Task<TimeTable> CreateTimeTableAsync(TimeTable timetables)
        {
            await _context.TimeTables.AddAsync(timetables);
            await _context.SaveChangesAsync();
            return timetables;
        }

        public async Task<TimeTable> UpdateTimeTableAsync(int id, UpdateTimeTableDTO updateDto)
        {
            var existingTimeTable = await _context.TimeTables.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTimeTable == null)
            {
                return null;
            }

            existingTimeTable.StudyDate = updateDto.StudyDate;
            existingTimeTable.StudyTime = updateDto.StudyTime;
            existingTimeTable.ClassId = updateDto.ClassId;
            existingTimeTable.TeacherId = updateDto.TeacherId;

            await _context.SaveChangesAsync();
            return existingTimeTable;
        }

        public async Task<bool> DeactivateTimeTableAsync(int id)
        {
            var timetables = await _context.TimeTables.FirstOrDefaultAsync(x => x.Id == id);
            if (timetables == null)
            {
                return false;
            }

            timetables.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateTimeTableAsync(int id)
        {
            var timetables = await _context.TimeTables.FirstOrDefaultAsync(x => x.Id == id);
            if (timetables == null || timetables.IsActive)
            {
                return false;
            }

            timetables.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TimeTable>> GetInactiveTimeTablesAsync()
        {
            return await _context.TimeTables
                                 .Where(f => !f.IsActive)
                                 .ToListAsync();
        }
    }
}
