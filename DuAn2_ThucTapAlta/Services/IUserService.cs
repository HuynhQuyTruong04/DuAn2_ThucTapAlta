using DuAn2_ThucTapAlta.DTO.User;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> ValidateUserAsync(string email, string password);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(int id, UpdateUserDTO updateDto);
        Task<bool> DeactivateUserAsync(int id);
        Task<bool> ActivateUserAsync(int id);
        Task<IEnumerable<User>> GetInactiveUsersAsync();
    }
}
