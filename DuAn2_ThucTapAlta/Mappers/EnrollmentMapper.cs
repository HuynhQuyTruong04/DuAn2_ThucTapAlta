using DuAn2_ThucTapAlta.DTO.Enrollment;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Mappers
{
    public static class EnrollmentMapper
    {
        public static EnrollmentDTO ToEnrollmentDTO(this Enrollment enrollmentModel)
        {
            return new EnrollmentDTO
            {
                Id = enrollmentModel.Id,
                EnrollmentDate = enrollmentModel.EnrollmentDate,
                Status = enrollmentModel.Status,
                StudentId = enrollmentModel.StudentId,
                ClassId = enrollmentModel.ClassId,
                CourseId = enrollmentModel.CourseId
            };
        }
        public static Enrollment ToEnrollmentFromCreateDTO(this CreateEnrollmentDTO enrollmentDto)
        {
            return new Enrollment
            {
                Id = enrollmentDto.Id,
                EnrollmentDate = enrollmentDto.EnrollmentDate,
                Status = enrollmentDto.Status,
                StudentId = enrollmentDto.StudentId,
                ClassId = enrollmentDto.ClassId,
                CourseId = enrollmentDto.CourseId
            };
        }
    }
}
