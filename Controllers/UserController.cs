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

        [HttpGet("UserByUsername/{username}")]
        public UserIdDTO GetUserByUsername(string username)
        {
            return _data.GetUserIdDTOByUsername(username);
        }

        [HttpPost("AddUser")]
        public bool AddUser(CreateAccountDTO UserToAdd) {
            return _data.AddUser(UserToAdd);
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers() 
        {
            return _data.GetAllUsers();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }

        //Update User Account
        [HttpPost("UpdateUser/{username}")]
        public bool UpdateUser(string username)
        {
            return _data.UpdateUsername(username);
        }

        //Delete User Account
        [HttpPost("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string? userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }
    }
}