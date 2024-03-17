namespace MyAnimeList.Models
{
    public class Anime
    {
        public int AnimeID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int? ReleaseYear { get; set; } // Nullable for INT in database
        public string Description { get; set; }
        public decimal? Rating { get; set; } // Nullable for DECIMAL in database
        public int? TotalEpisodes { get; set; } // Nullable for INT in database
        public string ImageURL { get; set; }
    }

}
