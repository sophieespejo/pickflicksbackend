using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pickflicksbackend.Models
{
    public class UserModel
    {
        public int Id { get; set; } // Each user gets their own id
        public string? Username { get; set; } // Changeable username, so always grab by id
        public string? Icon { get; set; } // Preset/changable icon
        public string? MyMWGId { get; set; } // String of the the user's MWG they created by id
        public string? ListOfMWGId { get; set; } // This is the string of each MWG name they are members of by id
        public string? FavoritedMWGId { get; set; } // This is the string of each MWG name they "favorited" by id
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        
        public UserModel(){}
    }
}