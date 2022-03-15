namespace pickflicksbackend.Models
{
    public class MWGModel
    {
        public int MWGId { get; set; }
        public string? GroupName { get; set; }
        public string? GroupCreatorId { get; set; }
        public string? MembersId { get; set; }
        public string? SuggestedMovies { get; set; }
        public bool IsDeleted { get; set; }
    }
}