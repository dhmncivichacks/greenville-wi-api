using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenvilleWiApi.Data.GoogleGeocoding
{
    public class GeometryType
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
