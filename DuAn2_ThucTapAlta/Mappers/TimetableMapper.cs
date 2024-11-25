using DuAn2_ThucTapAlta.DTO.Timetable;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Mappers
{
    public static class TimetableMapper
    {
        public static TimetableDTO ToTimetableDTO(this TimeTable timetableModel)
        {
            return new TimetableDTO
            {
                Id = timetableModel.Id,
                StudyDate = timetableModel.StudyDate,
                StudyTime = timetableModel.StudyTime,
                ClassId = timetableModel.ClassId,
                TeacherId = timetableModel.TeacherId
            };
        }
        public static TimeTable ToTimeTableFromCreateDTO(this CreateTimeTableDTO timetableDto)
        {
            return new TimeTable
            {
                Id = timetableDto.Id,
                StudyDate = timetableDto.StudyDate,
                StudyTime = timetableDto.StudyTime,
                ClassId = timetableDto.ClassId,
                TeacherId = timetableDto.TeacherId
            };
        }
    }
}

