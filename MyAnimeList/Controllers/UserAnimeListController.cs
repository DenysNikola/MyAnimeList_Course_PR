using Microsoft.AspNetCore.Mvc;
using MyAnimeList.Services;

namespace MyAnimeList.Controllers
{
    public class UserAnimeListController : Controller
    {
        private readonly AnimeDbService _animeDbService;

        public UserAnimeListController(AnimeDbService animeDbService)
        {
            _animeDbService = animeDbService;
        }

        public IActionResult userDetails(int userId)
        {
            var animeInfoList = _animeDbService.GetAnimeInfoForUser(userId);
            return View(animeInfoList);
        }
        
    }
}
