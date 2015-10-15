using Newtonsoft.Json;

namespace GreenvilleWiApi.Data.GoogleGeocoding
{
    /// <summary>
    /// A lat/long location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Initializes a new instance of the Location class
        /// </summary>
        public Location()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Location class with double lat/long
        /// </summary>
        public Location(double latitude, double longitude)
            : this((decimal)latitude, (decimal)longitude)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Location class with decimal lat/long
        /// </summary>
        public Location(decimal latitude, decimal longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Gets or sets the latitude
        /// </summary>
        [JsonProperty(PropertyName = "lat")]
        public decimal Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude
        /// </summary>
        [JsonProperty(PropertyName = "lng")]
        public decimal Longitude { get; set; }
    }
}
