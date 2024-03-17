using Microsoft.AspNetCore.Mvc;
using MyAnimeList.Models;
using MyAnimeList.Services;

namespace MyAnimeList.Controllers
{
    public class UserController : Controller
    {
        private readonly AnimeDbService _animeDbService;

        public UserController(AnimeDbService animeDbService)
        {
            _animeDbService = animeDbService ?? throw new ArgumentNullException(nameof(animeDbService));
        }

        public IActionResult userTable()
        {
            List<User> userList = _animeDbService.GetUserList();
            return View(userList);
        }

        public IActionResult UserDetails(int userId)
        {
            var user = _animeDbService.GetUserById(userId);

            if (user == null)
            {
                return NotFound(); // Handle user not found
            }

            return View(user);
        }
    }
}
