namespace DuAn2_ThucTapAlta.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Parents { get; set; }
        public string LoginCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<FeeInformation> FeeInformations { get; set; }
    }
}
