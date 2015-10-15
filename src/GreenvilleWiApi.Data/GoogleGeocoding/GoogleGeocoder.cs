using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GreenvilleWiApi.Data.GoogleGeocoding
{
    /// <summary>
    /// Proxy for submitting geocoding requests to google
    /// </summary>
    public static class GoogleGeocoder
    {
        /// <summary>
        /// Queries google's geocoding service
        /// </summary>
        public static async Task<List<GeocodeResult>> Geocode(string address)
        {
            // https://maps.googleapis.com/maps/api/geocode/json?address=W6683%20Spring%20Green%20Pl%20Greenville,%20WI%2054942
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://maps.googleapis.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("maps/api/geocode/json?address=" + address);

                if (response.IsSuccessStatusCode)
                {
                    // stringresult doesn't match geocoderesult :(
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeAnonymousType(stringResult, new { results = new List<GeocodeResult>() });
                    return result.results;
                }

                throw new Exception("Error reading from google geocoder: " + await response.Content.ReadAsStringAsync());
            }
        }
    }
}
