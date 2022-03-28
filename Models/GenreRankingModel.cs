namespace pickflicksbackend.Models
{
    public class GenreRankingModel
    {
        public int Id { get; set; }
        public int MWGId { get; set; }
        public int UserId { get; set; }        
        public int Biography { get; set; }
        public int FilmNoir { get; set; }
        public int GameShow { get; set; }
        public int Musical { get; set; }
        public int Sport { get; set; }
        public int Short { get; set; }
        public int Adult { get; set; }
        public int Adventure { get; set; }
        public int Fantasy { get; set; }
        public int Fantasy { get; set; }
        public int Animation { get; set; }
        public int Drama { get; set; }
        public int Horror { get; set; }
        public int Action { get; set; }
        public int Comedy { get; set; }
        public int History { get; set; }
        public int Western { get; set; }
        public int Thriller { get; set; }
        public int Crime { get; set; }
        public int Documentary { get; set; }
        public int ScienceFiction { get; set; }
        public int Mystery { get; set; }
        public int Music { get; set; }
        public int Romance { get; set; }
        public int Family { get; set; }
        public int War { get; set; }


        // MWG_Genres.push(#65656)

        // 656556.Drama = 4
        // 656556.Action = 1


        // Create MWG a Model gets made 
        // Each user will make a GenreRanking model
    }
}