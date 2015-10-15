using Newtonsoft.Json;

namespace GreenvilleWiApi.Data.GoogleGeocoding
{
    /// <summary>
    /// Geometric information about the address 
    /// </summary>
    public class Geometry
    {
        /// <summary>
        /// Gets or sets the lat/long location
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
