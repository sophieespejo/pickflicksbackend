namespace pickflicksbackend.Models
{
    public class MWGModel
    {
        public int Id { get; set; } // Own id for MWG
        public string? MWGName { get; set; } // String name for MWG 
        public string? GroupCreatorId { get; set; } // The groupCreator's id
        public string? MembersId { get; set; } // String of each members' id
        public string? UserSuggestedMovies { get; set; } // String or objects of userSuggested movies members for sure want included
        public bool IsDeleted { get; set; } // Soft delete
    }
}