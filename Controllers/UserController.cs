using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pickflicksbackend.Models;
using pickflicksbackend.Models.DTO;
using pickflicksbackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace pickflicksbackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;

        public UserController(UserService dataFromService) {
            _data = dataFromService;
        }

        // Add a user with a CreateAccuntDTO (will return bool)
        [HttpPost("AddUser")]
          public bool AddUser(CreateAccountDTO userToAdd)
        {
            return _data.AddUser(userToAdd);
        }

        // User login with LoginDTO (will return token)
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO user)
        {
            return _data.Login(user);
        } 

        // Get a list of all users by UserDTO (will return a list)
        [HttpGet("GetAllUsers")]
        public List<UserDTO> GetAllUsers()
        {
            return _data.GetAllUsers();
        }

        // Get a user's UserDTO by their string username (will return UserDTO)
        [HttpGet("GetUserByUsername/{username}")]
        public UserDTO GetUserByUsername(string? username)
        {
            return _data.GetUserByUsername(username);
        }

        // Get a user's UserDTO by their int id (will return UserDTO)
        [HttpGet("GetUserById/{id}")]
        public UserDTO GetUserById(int id)
        {
            return _data.GetUserById(id);
        }

        // Soft delete (will return bool)
        [HttpPost("DeleteUser/{username}")]
        public bool DeleteUser(string? username)
        {
            return _data.DeleteUser(username);
        }
    }
}