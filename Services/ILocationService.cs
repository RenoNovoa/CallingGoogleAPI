using Assessment7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment7.Services
{
    public interface ILocationService
    {
        Task<Location> GetLocationAsync(string zipCode);
        Task<IList<Result>> GetPlacesAsync(Location location);
    }
}
