using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
