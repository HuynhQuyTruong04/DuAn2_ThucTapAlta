namespace DuAn2_ThucTapAlta.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; } = true;

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
