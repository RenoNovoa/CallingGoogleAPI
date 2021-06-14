 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assessment7.Models;
using Assessment7.Services;

namespace Assessment7.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalService _service;
        private readonly ILocationService _locationService;

        public HomeController(IAnimalService service, ILocationService locationService)
        {
            _service = service;
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            Animal zoo = await _service.GetAsync<Animal>("https://gc-zoo.surge.sh/api/animals.json");

            //var zoo = await _service.GetAllAnimals();
            return View(zoo.results);
        }


        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Species(string SpeciesName)
        {
            string baseUrl = "https://gc-zoo.surge.sh";
            string endpoint = $"/api/species/{SpeciesName}.json";
            Species animal = await _service.GetAsync<Species>(baseUrl + endpoint);

            //var animal = await _service.GetAnAnimal(SpeciesName);
            return View(animal);
        }

        public async Task<IActionResult> GetDonuts(string id)
        {
            var donutBaseUrl = "https://grandcircusco.github.io/demo-apis/";
            var donutEndPoint = $"donuts/{id}.json";
            Donut donut = await _service.GetAsync<Donut>(donutBaseUrl + donutEndPoint);

            return View(donut);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
