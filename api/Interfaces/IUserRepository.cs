using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using api.Models;
using api.Dtos.User;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(); 
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User userModel);
        Task<User?> UpdateAsync(int id, UpdateUserRequestDto  userRequestDto);
        Task<User?> DeleteAsync(int id); 
    }
}