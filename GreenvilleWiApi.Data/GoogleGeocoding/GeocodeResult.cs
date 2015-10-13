using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenvilleWiApi.Data.GoogleGeocoding
{
    public class GeocodeResult
    {
        [JsonProperty(PropertyName = "address_components")]
        public List<Component> Components { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public GeometryType Geometry { get; set; }
    }
}
