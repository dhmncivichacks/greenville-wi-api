using System.Collections.Generic;
using Newtonsoft.Json;

namespace GreenvilleWiApi.Data.GoogleGeocoding
{
    /// <summary>
    /// A result for google's geocoding service
    /// </summary>
    public class GeocodeResult
    {
        /// <summary>
        /// Gets or sets a list of address components
        /// </summary>
        [JsonProperty(PropertyName = "address_components")]
        public List<Component> Components { get; set; }

        /// <summary>
        /// Gets or sets the geometry of the result
        /// </summary>
        [JsonProperty(PropertyName = "geometry")]
        public Geometry Geometry { get; set; }
    }
}
