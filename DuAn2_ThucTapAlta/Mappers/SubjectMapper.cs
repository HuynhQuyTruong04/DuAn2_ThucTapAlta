using DuAn2_ThucTapAlta.DTO.Subject;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Mappers
{
    public static class SubjectMapper
    {
        public static SubjectDTO ToSubjectDTO(this Subject subjectModel)
        {
            return new SubjectDTO
            {
                Id = subjectModel.Id,
                SubjectName = subjectModel.SubjectName,
                ClassId = subjectModel.ClassId
            };
        }
        public static Subject ToSubjectFromCreateDTO(this CreateSubjectDTO subjectDto)
        {
            return new Subject
            {
                Id = subjectDto.Id,
                SubjectName = subjectDto.SubjectName,
                ClassId = subjectDto.ClassId
            };
        }
    }
}
