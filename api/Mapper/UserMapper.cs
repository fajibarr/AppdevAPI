using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using api.Dtos.User;
using api.Models;

namespace api.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Symbol = userModel.Symbol,
                Email = userModel.Email,
                Username = userModel.Username,
                Address = userModel.Address
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Symbol = userDto.Symbol,
                Email = userDto.Email,
                Username = userDto.Username,
                Address = userDto.Address
            };
        }
    }
}