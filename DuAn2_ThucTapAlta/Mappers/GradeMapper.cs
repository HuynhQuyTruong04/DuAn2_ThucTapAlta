using DuAn2_ThucTapAlta.DTO.Grade;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Mappers
{
    public static class GradeMapper
    {
        public static GradeDTO ToGradeDTO(this Grade gradeModel)
        {
            return new GradeDTO
            {
                Id = gradeModel.Id,
                Score = gradeModel.Score,
                GradeType = gradeModel.GradeType,
                StudentId = gradeModel.StudentId,
                ClassId = gradeModel.ClassId
            };
        }

        public static Grade ToGradeFromCreateDTO(this CreateGradeDTO gradeDto)
        {
            return new Grade
            {
                Id = gradeDto.Id,
                Score = gradeDto.Score,
                GradeType = gradeDto.GradeType,
                StudentId = gradeDto.StudentId,
                ClassId = gradeDto.ClassId
            };
        }
    }
}
