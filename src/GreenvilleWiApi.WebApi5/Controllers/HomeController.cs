using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace GreenvilleWiApi.WebApi5.Controllers
{
    /// <summary>
    /// Home page controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Gets the home page
        /// </summary>
        [Route("/")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
