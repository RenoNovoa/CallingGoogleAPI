using Assessment7.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Assessment7.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly HttpClient _client;

        public AnimalService(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetAsync<T>(string requestUri) where T : class
        {
            return await _client.GetFromJsonAsync<T>(requestUri);//This give us the flexibility to call end or full Url 
        }

        // PascalCase
        public async Task<Animal> GetAllAnimals()
        {
            var response = await _client.GetAsync("/api/animals.json");
            // camelCase
            var jsonData = await response.Content.ReadAsStringAsync();
            var zoo = JsonConvert.DeserializeObject<Animal>(jsonData);

            return await _client.GetFromJsonAsync<Animal>("/api/animals.json");
        }

        public async Task<Species> GetAnAnimal(string SpeciesName)
        {
            var result = await _client.GetFromJsonAsync<Species>($"/api/species/{SpeciesName}.json");
            return result;
        }

        //public async Task<GeoCode> GetLongLat(float lat, float flot)
        //{
        //    var Coordinates = await _client.GetFromJsonAsync<GeoCode>
        //        ($"/geocode/json?address=g1l2h5&key=AIzaSyA59jOpjCFfmjB2XQT-TsqeADzz_" +
        //        $"-92fFs&fbclid=IwAR3Ioyztytrz_fb9v1bcBeNL9KCFOOgBMBZfPkb5JIrTub4ohnRlZAn-bk8");
        //    return Coordinates;

        //}
        //public float lat { get; set; }
        //public float lng { get; set; }
    }
}
