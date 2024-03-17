using Microsoft.EntityFrameworkCore;
using MyAnimeList.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MyAnimeList.Services
{
    public class AnimeDbService
    {
        private readonly AnimeDbContext _dbContext;

        public AnimeDbService(AnimeDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Anime> GetAnimeList()
        {
            return _dbContext.Anime.ToList();
        }

        public Anime GetAnimeById(int AnimeId)
        {
            return _dbContext.Anime.Find(AnimeId);
        }

        public void UpdateAnime(Anime updatedAnime)
        {
            var existingAnime = _dbContext.Anime.Find(updatedAnime.AnimeID);

            if (existingAnime != null)
            {
                
                _dbContext.Attach(existingAnime);

                
                _dbContext.Entry(existingAnime).CurrentValues.SetValues(updatedAnime);

                
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Anime not found for the given ID.", nameof(updatedAnime.AnimeID));
            }
        }

        public List<User> GetUserList()
        {
            return _dbContext.User.ToList();
        }

        public User GetUserById(int userId)
        {
            return _dbContext.User.Find(userId);
        }

        public void UpdateUser(User updatedUser)
        {
            var existingUser = _dbContext.User.Find(updatedUser.UserID);

            if (existingUser != null)
            {
               
                _dbContext.Attach(existingUser);

                
                _dbContext.Entry(existingUser).CurrentValues.SetValues(updatedUser);

                
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("User not found for the given ID.", nameof(updatedUser.UserID));
            }
        }

        public List<AnimeInfo> GetAnimeInfoForUser(int userId)
        {
            return _dbContext.UserAnimeList
                .Where(u => u.UserID == userId)
                .Include(u => u.User)
                .Include(u => u.Anime)
                .Select(u => new AnimeInfo
                {
                    AnimeID = u.AnimeID,
                    UserName = u.User.Username,
                    AnimeTitle = u.Anime.Title,
                    ImageUrl = u.Anime.ImageURL,
                    Score = u.Score
                })
                .ToList();
        }


    }

    public class AnimeDbContext : DbContext
    {
        public DbSet<Anime> Anime { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<UserAnimeList> UserAnimeList { get; set; }


        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite("Data Source=D:\\nure\\course4\\csharp\\Mal_Data\\mal_clone.db");
        }

    }


}
