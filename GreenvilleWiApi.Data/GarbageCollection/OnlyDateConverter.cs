using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace GreenvilleWiApi.Data.GarbageCollection
{
    /// <summary>
    /// Only writes out the date part of the DateTime
    /// </summary>
    public class OnlyDateConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Initializes a new instance of the OnlyDateConverter class
        /// </summary>
        public OnlyDateConverter()
        {
            this.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
