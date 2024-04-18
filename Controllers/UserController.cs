using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Security.Claims;
using TODOLIST.Data.Entities;
using TODOLIST.Data.Models;
using TODOLIST.Services.Implementations;
using TODOLIST.Services.Interfaces;

namespace TODOLIST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/getallusers")]
        public ActionResult<IEnumerable<ToDo>> Get()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("/getuserbyid/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var todo = _userService.GetUserById(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            var user = new User
            {
                UserName = userCreateDto.UserName,
                Address = userCreateDto.Address,
                Email = userCreateDto.Email,
            };

            try
            {
                var createdUser = _userService.CreateUser(user);
                return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUser);
            }
            catch
            {
                return Conflict("Error al crear el todo. Conflicto detectado");
            }
        }
        [HttpPut]
        public IActionResult UpdateUser(int userId, [FromBody] UserUpdateDto userUpdateDto)
        {
            var updatedUser = new User
            {
                Email = userUpdateDto.Email,
                UserName = userUpdateDto.UserName,
                Address = userUpdateDto.Address,
            };
            try
            {
                var result = _userService.UpdateUser(userId, updatedUser);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (_userService.DeleteUser(id))
                {
                    return Ok($"User {id} eliminado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Forbid();
        }
    }
}