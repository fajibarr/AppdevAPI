using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using api.Interfaces;
using api.Models;
using api.Data;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using api.Dtos.User;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync(); 
            return userModel;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(userModel == null)
            {
                return null;
            }
            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto userRequestDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(existingUser == null)
            {
                return null;
            }
            existingUser.Symbol = userRequestDto.Symbol;
            existingUser.Email = userRequestDto.Email;
            existingUser.Username = userRequestDto.Username;
            existingUser.Address = userRequestDto.Address;

            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}