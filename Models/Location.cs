using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Assessment7.Models
{
    //public class GeoCode
    //{
    //    public Result[] results { get; set; }
    //}

    //public class Result
    //{
    //    public string formatted_address { get; set; }
    //    public Geometry geometry { get; set; }
    //}

    //public class Geometry
    //{
    //    public Location location { get; set; }
    //}

    public class Location
    {
        [JsonProperty(PropertyName = "lat")]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public float Longitude { get; set; }
    }
}
