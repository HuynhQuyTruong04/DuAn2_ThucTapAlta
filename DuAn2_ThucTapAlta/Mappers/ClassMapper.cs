using DuAn2_ThucTapAlta.DTO.Class;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Mappers
{
    public static class ClassMapper
    {
        public static ClassDTO ToClassDTO(this Class classModel)
        {
            return new ClassDTO
            {
                Id = classModel.Id,
                TeacherId = classModel.TeacherId,
                NameClass = classModel.NameClass,
                Description = classModel.Description,
                MaxStudent = classModel.MaxStudent,
                TuitionFee = classModel.TuitionFee,
                Image = classModel.Image,
                AcademicYear = classModel.AcademicYear
            };
        }

        public static Class ToClassFromCreateDTO(this CreateClassDTO classDto) 
        {
            return new Class
            {
                Id = classDto.Id,
                TeacherId = classDto.TeacherId,
                NameClass = classDto.NameClass,
                Description = classDto.Description,
                MaxStudent = classDto.MaxStudent,
                TuitionFee = classDto.TuitionFee,
                Image = classDto.Image,
                AcademicYear = classDto.AcademicYear
            };
        }
    }
}
