using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenvilleWiApi.Data.GoogleGeocoding
{
    public class Location
    {
        public Location()
        {
        }

        public Location(double latitude, double longitude)
            : this((decimal)latitude, (decimal)longitude)
        {
        }

        public Location(decimal latitude, decimal longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        [JsonProperty(PropertyName = "lat")]
        public decimal Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public decimal Longitude { get; set; }
    }
}
