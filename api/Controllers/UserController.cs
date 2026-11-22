using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Mapper;
using api.Dtos.User;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepo;
        public UserController(ApplicationDBContext context, IUserRepository userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAllAsync();
            var userDto = users.Select(u => u.ToUserDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
         public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDTO();
            await _userRepo.CreateAsync(userModel);
            return CreatedAtAction(nameof(GetById), new {id =  userModel.Id}, userModel.ToUserDto());
        }

        [HttpPut("{id:int}")] 
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            var userModel = await _userRepo.UpdateAsync(id, updateDto);
            if(userModel == null)
        {
            return NotFound();
        }
            return Ok(userModel.ToUserDto());
        }

        [HttpDelete("{id:int}")] 
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userModel = _userRepo.DeleteAsync(id);
            if(userModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}