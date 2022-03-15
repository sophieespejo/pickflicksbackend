using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pickflicksbackend.Models
{
    public class UserModel
    {
        public int UserId { get; set; } // Each user gets their own ID
        public string? Username { get; set; } // Changeable username, so always grab by Id
        public string? Icon { get; set; } // Preset/changable icon
        public string? ListOfMWG { get; set; }
        public string? FavoritedMWG { get; set; } // This is the string? GroupName of each MWG
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        
        public UserModel(){}
    }
}