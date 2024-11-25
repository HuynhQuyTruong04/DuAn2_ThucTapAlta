using DuAn2_ThucTapAlta.DTO.Teacher;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Mappers
{
    public static class TeacherMapper
    {
        public static TeacherDTO ToTeacherDTO(this Teacher teacherModel)
        {
            return new TeacherDTO
            {
                Id = teacherModel.Id,
                UserId = teacherModel.UserId,
                FirstName = teacherModel.FirstName,
                LastName = teacherModel.LastName,
                Gender = teacherModel.Gender,
                Birthday = teacherModel.Birthday,
                Phone = teacherModel.Phone,
                Email = teacherModel.Email,
                Address = teacherModel.Address,
                SubjectSpecialization = teacherModel.SubjectSpecialization,
                CreateDate = teacherModel.CreateDate,
                UpdateDate = teacherModel.UpdateDate
            };
        }

        public static Teacher ToTeacherFromCreateDTO(this CreateTeacherDTO teacherDto)
        {
            return new Teacher
            {
                Id = teacherDto.Id,
                UserId = teacherDto.UserId,
                FirstName = teacherDto.FirstName,
                LastName = teacherDto.LastName,
                Gender = teacherDto.Gender,
                Birthday = teacherDto.Birthday,
                Phone = teacherDto.Phone,
                Email = teacherDto.Email,
                Address = teacherDto.Address,
                SubjectSpecialization = teacherDto.SubjectSpecialization,
                CreateDate = teacherDto.CreateDate,
                UpdateDate = teacherDto.UpdateDate
            };
        }
    }
}
