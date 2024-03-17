using System.ComponentModel.DataAnnotations;

namespace MyAnimeList.Models
{
    public class UserAnimeList
    {
        [Key]
        public int ListID { get; set; }

        public int UserID { get; set; }
        public User User { get; set; } // Navigation property for User entity

        public int AnimeID { get; set; }
        public Anime Anime { get; set; } // Navigation property for Anime entity

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        public int Score { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
