using Microsoft.AspNetCore.Mvc;
using MyAnimeList.Models;
using MyAnimeList.Services;

namespace MyAnimeList.Controllers
{
    public class AnimeController : Controller
    {
        private readonly AnimeDbService _animeDbService;

        public AnimeController(AnimeDbService animeDbService)
        {
            _animeDbService = animeDbService ?? throw new ArgumentNullException(nameof(animeDbService));
        }
        public IActionResult AnimeDetails(int AnimeID)
        {
            var selectedAnime = _animeDbService.GetAnimeById(AnimeID);

            if (selectedAnime == null)
            {
                return NotFound(); // Handle the case where the anime is not found
            }

            return View(selectedAnime);
        }

        public IActionResult Index()
        {
            List<Anime> animeList = _animeDbService.GetAnimeList();
            return View(animeList);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Anime anime = _animeDbService.GetAnimeById(id);

            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        [HttpPost]
        public IActionResult Edit(Anime updatedAnime)
        {
            if (ModelState.IsValid)
            {
                _animeDbService.UpdateAnime(updatedAnime);
                return RedirectToAction("Index");
            }

            return View(updatedAnime);
        }
    }
}
