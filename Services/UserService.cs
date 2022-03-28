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

        public bool DoesUserExists(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
        }

        public PasswordDTO HashPassword(string? password)
        {
            PasswordDTO newHashedPassword = new PasswordDTO();
            byte[] SaltBytes = new byte[64];
            var provider = RandomNumberGenerator.Create();
            provider.GetNonZeroBytes(SaltBytes);
            var Salt = Convert.ToBase64String(SaltBytes);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);
            var HashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = HashPassword;
            return newHashedPassword;
        }

        public bool AddUser(CreateAccountDTO userToAdd)
        {
            bool result = false;
            if (!DoesUserExists(userToAdd.username))
            {
                UserModel newUser = new UserModel();
                newUser.Id = 0;
                newUser.Username = userToAdd.Username;
                newUser.Icon = userToAdd.Icon;
                newUser.MyMWGId = userToAdd.MyMWGId;
                newUser.ListOfMWGId = userToAdd.ListOfMWGId;
                newUser.FavoritedMWGId = userToAdd.FavoritedMWGId;

                var hashedPassword = HashPassword(userToAdd.Password);
                newUser.Salt = hashedPassword.Salt;
                newUser.Hash = hashedPassword.Hash;
                
                _context.Add(newUser);

                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public bool VerifyUserPassword(string? password, string? storedHash, string? storedSalt)
        {
            var SaltBytes = Convert.FromBase64String(StoredSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == StoredHash;
        }


        public IActionResult Login([FromBody] LoginDTO user)
        {
            IActionResult Result = Unauthorized();
            if (DoesUserExists(user.Username))
            {
                var foundUser = FindUserByUsername(user.Username);
                var verifyPass = VerifyUserPassword(user.Password, foundUser.Hash, foundUser.Salt);
                if (verifyPass)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ILoveToSolveKatasAllDay@209"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    Result = Ok(new { Token = tokenString });
                    
                }
            }
            return Result;
        }

        public UserDTO GetUserByUsername(string? username)
        {
            var dtoInfo = new UserDTO();
            var foundUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);
            dtoInfo.Id = foundUser.Id;
            dtoInfo.Username = foundUser.Username;
            dtoInfo.Icon = foundUser.Icon;
            dtoInfo.MyMWGId = foundUser.MyMWGId;
            dtoInfo.ListOfMWGId = foundUser.ListOfMWGId;
            dtoInfo.FavoritedMWGId = foundUser.FavoritedMWGId;

            return dtoInfo;
        }

        public UserDTO GetUserById(int id)
        {
            var dtoInfo = new UserDTO();
            var foundUser = _context.UserInfo.SingleOrDefault(user => user.Id == id);
            dtoInfo.Id = foundUser.Id;
            dtoInfo.Username = foundUser.Username;
            dtoInfo.Icon = foundUser.Icon;
            dtoInfo.MyMWGId = foundUser.MyMWGId;
            dtoInfo.ListOfMWGId = foundUser.ListOfMWGId;
            dtoInfo.FavoritedMWGId = foundUser.FavoritedMWGId;

            return dtoInfo;
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserModel> AllUser = new List<UserModel>();
            AllUser= _context.UserInfo.ToList();
            List<UserDTO>PublicDataAllUser = new List<UserDTO>();
            foreach (UserModel User in AllUser)
            {
                UserDTO PublicUserInfo = GetUserByUsername(user.Username);
                PublicDataAllUser.Add(PublicUserInfo);
            }
            return PublicDataAllUser;
        }

        public bool DeleteUser(string? username)
        {
            UserModel foundUser = FindUserByUsername(username);
            bool result=false;
            if(foundUser!=null)
            {
                foundUser.IsDeleted=true;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges()!=0;
            }
            return result;
        }

        // Only use this for backend, NEVER PASS DATA TO FRONTEND 
        public UserModel FindUserByUsername(string ?username)
        {
            return _context.UserInfo.SingleOrDefault(item => item.Username == username);
        }
    }
}