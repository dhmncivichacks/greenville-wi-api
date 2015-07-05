﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Geocoding;
using Geocoding.Google;
using GreenvilleWiApi.Data.GarbageCollection;

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
        public IEnumerable<GarbageCollectionEvent> Get(string addr, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (startDate < this.CentralTimeDate || startDate == null)
                startDate = this.CentralTimeDate;

            if (endDate > this.CentralTimeDate.AddMonths(3) || endDate == null)
                endDate = startDate.Value.AddMonths(1);

            var geocoder = new GoogleGeocoder();
            var address = (
                from a in geocoder.Geocode(addr)
                from c in a.Components
                from t in c.Types
                where t == GoogleAddressType.PostalCode && c.LongName == "54942"
                select a).FirstOrDefault();

            if (address != null)
            {
                var garbageDay = GarbageDayCalculator.CalculateGarbageDay(address.Coordinates);
                return GarbageDayCalculator.CalculateCollectionEvents(garbageDay, startDate.Value, endDate.Value);
            }

            return new List<GarbageCollectionEvent>();
        }
    }
}