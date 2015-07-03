using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GreenvilleWiApi.WebApi.Models;

namespace GreenvilleWiApi.WebApi.Controllers
{
    /// <summary>
    /// Serves queries for when garbage collection is happening
    /// </summary>
    public class GarbageCollectionController : ApiController
    {
        /// <summary>
        /// Gets the current time in the Central time zone
        /// </summary>
        private DateTime CentralTimeDate
        {
            get
            {
                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            }
        }

        /// <summary>
        /// Gets the upcoming garbage collection dates, with a range optionally passed in
        /// </summary>
        public IEnumerable<GarbageCollectionModel> Get(DateTime? startDate, DateTime? endDate)
        {
            if (startDate < this.CentralTimeDate || startDate == null)
                startDate = this.CentralTimeDate;

            if (endDate > this.CentralTimeDate.AddMonths(3) || endDate == null)
                endDate = startDate.Value.AddMonths(1);

            return new List<GarbageCollectionModel>();
        }
    }
}
