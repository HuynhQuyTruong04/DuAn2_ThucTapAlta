using System.Xml;

namespace DuAn2_ThucTapAlta.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string SubjectSpecialization { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; } = true;

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<TimeTable> TimeTables { get; set; }
        public ICollection<Salary> Salaries { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}
