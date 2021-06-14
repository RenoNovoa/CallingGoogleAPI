using Assessment7.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Assessment7.Controllers
{
    public class PlacesController : Controller
    {
        private readonly ILocationService _locationService;

        public PlacesController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetPlaces(string address, int radius, string type)
        {
            var location = await _locationService.GetLocationAsync(address);

            var places = await _locationService.GetPlacesAsync(location, radius, type);
            ViewData["type"] = type;
            return View(places);
        }
    }
}
