namespace DuAn2_ThucTapAlta.DTO.Teacher
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string SubjectSpecialization { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }      
    }
}
