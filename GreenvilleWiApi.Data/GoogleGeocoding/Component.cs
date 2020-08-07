using System.Collections.Generic;
using Newtonsoft.Json;

namespace GreenvilleWiApi.Data.GoogleGeocoding
{
    /// <summary>
    /// An address component
    /// </summary>
    public class Component
    {
        /// <summary>
        /// Gets or sets the long name of the component
        /// </summary>
        [JsonProperty(PropertyName = "long_name")]
        public string LongName { get; set; }

        /// <summary>
        /// Gets or sets the short name of the component
        /// </summary>
        [JsonProperty(PropertyName = "short_name")]
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the types of the component
        /// </summary>
        [JsonProperty(PropertyName = "types")]
        public List<string> Types { get; set; }
    }
}
