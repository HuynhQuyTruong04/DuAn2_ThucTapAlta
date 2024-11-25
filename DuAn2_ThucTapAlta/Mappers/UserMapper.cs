using DuAn2_ThucTapAlta.DTO.User;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToUserDTO(this User userModel)
        {
            return new UserDTO
            {
                Id = userModel.Id,
                RoleId = userModel.RoleId,
                Email = userModel.Email,
                Password = userModel.Password,
                CreateDate = userModel.UpdateDate,
                UpdateDate = userModel.UpdateDate
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserDTO userDto)
        {
            return new User
            {
                Id = userDto.Id,
                RoleId = userDto.RoleId,
                Email = userDto.Email,
                Password = userDto.Password,
                CreateDate = userDto.CreateDate,
                UpdateDate = userDto.UpdateDate
            };
        }
    }
}
