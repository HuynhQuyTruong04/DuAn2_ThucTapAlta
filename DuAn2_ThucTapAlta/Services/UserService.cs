using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.User;
using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DuAn2_ThucTapAlta.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _context;

        public UserService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(s => s.Id == id && s.IsActive);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Where(u => u.IsActive).ToListAsync();
        }

        public async Task<User> ValidateUserAsync(string email, string password)
        {
            // Tìm người dùng theo email từ database
            var user = await _context.Users
                .Include(u => u.Role) // Bao gồm vai trò người dùng
                .SingleOrDefaultAsync(u => u.Email == email);

            var hashedPassword = HashPassword(password);
            if (user.Password != hashedPassword)
            {
                return null; // Mật khẩu không đúng
            }

            return user;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.Password = HashPassword(user.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(int id, UpdateUserDTO updateDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.RoleId = updateDto.RoleId;
            existingUser.Email = updateDto.Email;
            existingUser.Password = updateDto.Password;
            existingUser.CreateDate = updateDto.CreateDate;
            existingUser.UpdateDate = updateDto.UpdateDate;

            await _context.SaveChangesAsync();
            return existingUser;
        }
        public async Task<bool> DeactivateUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (user == null)
            {
                return false;
            }

            user.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null || user.IsActive)
            {
                return false;
            }

            user.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetInactiveUsersAsync()
        {
            return await _context.Users
                                 .Where(f => !f.IsActive)
                                 .ToListAsync();
        }
    }
}
