using Microsoft.AspNetCore.Mvc;
using mvcprojectfinal.Models;

namespace mvcprojectfinal.Controllers
{
    public class MainPageController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            List<City> cities = context.cities.ToList();
            return View(cities);
        }
        [HttpGet]
        public IActionResult getAllHotelsByCity()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAllHotelsByCity(int cityID)
        {
            List<Hotels> hotels = context.hotels.Where(h => h.CityID == cityID).ToList();
            return View(hotels);
        }
    }
}
