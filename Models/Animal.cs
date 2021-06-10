using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment7.Models
{

    public class Animal
    {
       
        public AnimalResult[] results { get; set; }
        
    }

    public class AnimalResult
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public SpeciesName Species { get; set; }
    }

    public class SpeciesName
    {
        public string Name { get; set; }
    }
}
