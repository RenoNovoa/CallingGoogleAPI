using Assessment7.Models;
using System.Threading.Tasks;

namespace Assessment7.Services
{
    public interface IAnimalService
    {
        Task<T> GetAsync<T>(string path) where T : class;

        Task<Animal> GetAllAnimals();

        Task<Species> GetAnAnimal(string name);
    }
}