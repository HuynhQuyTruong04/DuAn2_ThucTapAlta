namespace DuAn2_ThucTapAlta.DTO.User
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassWord { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int RoleId { get; set; }
    }
}
