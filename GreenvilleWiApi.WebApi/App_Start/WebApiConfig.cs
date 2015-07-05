using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace GreenvilleWiApi.WebApi
{
    /// <summary>
    /// Configuration for the Web API
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers configuration details with Web API
        /// </summary>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Use camel case for JSON serialization
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
