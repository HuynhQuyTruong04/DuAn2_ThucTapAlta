using DuAn2_ThucTapAlta.DTO.Course;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Mappers
{
    public static class CourseMapper
    {
        public static CourseDTO ToCourseDTO(this Course courseModel)
        {
            return new CourseDTO
            {
                Id = courseModel.Id,
                NameCourse = courseModel.NameCourse,
                Description = courseModel.Description,
                CreateDate = courseModel.CreateDate,
                UpdateDate = courseModel.UpdateDate,
            };
        }

        public static Course ToCourseFromCreateDTO(this CreateCourseDTO courseDto)
        {
            return new Course
            {
                Id = courseDto.Id,
                NameCourse = courseDto.NameCourse,
                Description = courseDto.Description,
                CreateDate = courseDto.CreateDate,
                UpdateDate = courseDto.UpdateDate,
            };
        }
    }
}
