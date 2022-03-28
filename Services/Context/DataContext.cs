using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pickflicksbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace pickflicksbackend.Services.Context
{
    public class DataContext : DbContext 
    {
        public DbSet<UserModel> UserInfo { get; set;}
        public DbSet<MWGModel> MWGInfo { get; set; }
        // public DbSet<GenreRankingModel> GenreRankingInfo {get; set;}
        public DataContext(DbContextOptions options ): base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            var UserData = new List<UserModel>()
            {
                new UserModel() {
                    Id = 1,
                    Username = "Dylan",
                    Icon = "",
                    MyMWGId = "",
                    FavoritedMWGId = "",
                    Salt = "6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==",
                    Hash = "BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==",
                }, 
                new UserModel() {
                    Id = 2,
                    Username = "Sophie",
                    Icon = "",
                    MyMWGId = "",
                    FavoritedMWGId = "",
                    Salt = "6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==",
                    Hash = "BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==",
                }, 
                new UserModel() {
                    Id = 3,
                    Username = "An",
                    Icon = "",
                    MyMWGId = "",
                    FavoritedMWGId = "",
                    Salt = "6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==",
                    Hash = "BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==",
                }, 
                new UserModel() {
                    Id = 4,
                    Username = "Angel",
                    Icon = "",
                    MyMWGId = "",
                    FavoritedMWGId = "",
                    Salt = "6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==",
                    Hash = "BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==",
                }
            };
            builder.Entity<UserModel>().HasData(UserData);

            var MWGData = new List<MWGModel>()
            {
                new MWGModel() {
                    Id = 1,
                    MWGName = "First MWG",
                    GroupCreatorId = "1",
                    MembersId = "2,3",
                    UserSuggestedMovies = "Toy Story 3, Wolf of Wallstreet",
                    IsDeleted = false
                },
                new MWGModel() {
                    Id = 2,
                    MWGName = "Second MWG",
                    GroupCreatorId = "2",
                    MembersId = "1,4",
                    UserSuggestedMovies = "Encanto",
                    IsDeleted = false
                },
                new MWGModel() {
                    Id = 3,
                    MWGName = "Third MWG",
                    GroupCreatorId = "3",
                    MembersId = "1,2",
                    UserSuggestedMovies = "Frozen lol",
                    IsDeleted = false
                },
            };
           builder.Entity<MWGModel>().HasData(MWGData);
        }
    }
}