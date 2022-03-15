using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using pickflicksbackend.Models;
using pickflicksbackend.Models.DTO;
using pickflicksbackend.Services;
using pickflicksbackend.Services.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace pickflicksbackend.Services
{
    public class UserService : ControllerBase
    {
        private readonly DataContext _context;
        public UserService(DataContext context) 
        {
            _context = context;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _context.UserInfo;
        }

        public bool DoesUserExist(string? username) 
        {
            // Check the table to see if username exists
            // Single or default
            // If one item matches our condition that item will be returned
            // If no items match the condition a null will be returned
            // If multiple items match the condition an error will occur >>
            // UserModel foundUser = _context.UserInfo.SingleOrDefault( user => user.Username == username);
            // if (foundUser != null ) {
            //     // The user does exist
            // } else {
            //     // The user does not exist
            // }
            
            return _context.UserInfo.SingleOrDefault( user => user.Username == username) != null;
        }

        public UserModel GetUserByUsername(string username)
        {
            return _context.UserInfo.SingleOrDefault( user => user.Username == username);
        }

        public UserIdDTO GetUserIdDTOByUsername(string username)
        {
            var UserInfo = new UserIdDTO();
            var foundUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);
            UserInfo.UserId = foundUser.Id;
            UserInfo.Username = foundUser.Username;
            return UserInfo;
        }

        public IActionResult Login(LoginDTO user)
        {
            IActionResult Result = Unauthorized();
            // Check to see if the user exist
            if (DoesUserExist(user.Username)) {
                // true
                var foundUser = GetUserByUsername(user.Username);
                // Check to see if the password is correct
                if (VerifyUserPassword(user.Password, foundUser.Hash, foundUser.Salt)) {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DayClassSuperDuperSecretKey@209"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
                } 
            }
            return Result;
        }

        public bool AddUser(CreateAccountDTO UserToAdd) 
        {
            bool result = false;
            if (!DoesUserExist(UserToAdd.Username)) {
                // The user does exist
                UserModel newUser = new UserModel();
                var hashedPassword = HashPassword(UserToAdd.Password);
                newUser.Id = UserToAdd.Id;
                newUser.Username = UserToAdd.Username;
                newUser.Salt = hashedPassword.Salt;
                newUser.Hash = hashedPassword.Hash;

                _context.Add(newUser);
                
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public PasswordDTO HashPassword(string? password) 
        {
            PasswordDTO newHashedPassword = new PasswordDTO();
            byte[] SaltBytes = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltBytes);
            var Salt = Convert.ToBase64String(SaltBytes);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);
            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }

        public bool VerifyUserPassword(string? Password, string? storedHash, string? storedSalt)
        {
            var SaltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == storedHash;
        }
        
        public bool UpdateUser(UserModel userToUpdate)
        {
            //This one is sednig over the whole object to be updated
            _context.Update<UserModel>(userToUpdate);
            return _context.SaveChanges() !=0; 
        }

        public bool UpdateUsername(string Username)
        {
            //This one is sednig over just the username.
            //Then you have to get the object to then be updated.
            UserModel foundUser = GetUserByUsername(Username);
            bool result = false;
            if(foundUser != null)
            {
                //A user was foundUser
                foundUser.Username = Username;
                _context.Update<UserModel>(foundUser);
               result =  _context.SaveChanges() != 0;
            }
            return result;
        }

        public bool DeleteUser(string Username)
        {
            //This one is sednig over just the username.
            //Then you have to get the object to then be updated.
            UserModel foundUser = GetUserByUsername(Username);
            bool result = false;
            if(foundUser != null)
            {
                //A user was foundUser
                foundUser.Username = Username;
                _context.Remove<UserModel>(foundUser);
               result =  _context.SaveChanges() != 0;
            }
            return result;
        }
    }
}