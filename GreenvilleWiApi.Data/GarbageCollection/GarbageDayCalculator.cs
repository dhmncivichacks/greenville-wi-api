using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocoding;

namespace GreenvilleWiApi.Data.GarbageCollection
{
    /// <summary>
    /// Defines the available types of garbage collection
    /// </summary>
    public enum GarbageCollectionType
    {
        Trash,
        Recycling
    }

    /// <summary>
    /// Calculates garbage day information
    /// </summary>
    public static class GarbageDayCalculator
    {
        /// <summary>
        /// Maps years to the holidays that affect garbage collection for that year
        /// </summary>
        private static readonly Dictionary<int, List<DateTime>> HOLIDAYS = new Dictionary<int, List<DateTime>>
        {
            { 2015, new List<DateTime>
                {
                    new DateTime(2015, 1, 1),
                    new DateTime(2015, 11, 26),
                    new DateTime(2015, 12, 25)
                }
            },
            { 2016, new List<DateTime>
                {
                    new DateTime(2015, 1, 1),
                    new DateTime(2015, 11, 24)
                }
            }
        };

        /// <summary>
        /// Lat/Long polygon enclosing the Wednesday trash zone
        /// </summary>
        private static readonly List<Location> WEDNESDAY = new List<Location>
        {
            new Location(44.306038, -88.546286),
            new Location(44.300387, -88.536758),
            new Location(44.296271, -88.527746), 
            new Location(44.290558, -88.516760),
            new Location(44.309601, -88.516331),
            new Location(44.309601, -88.536930),
            new Location(44.312365, -88.537016),
            new Location(44.311935, -88.546543),
            new Location(44.306038, -88.546286)
        };

        /// <summary>
        /// Lat/Long polygon enclosing the Friday trash zone
        /// </summary>
        private static readonly List<Location> FRIDAY = new List<Location>
        {
            new Location(44.309662, -88.516245),
            new Location(44.290497, -88.516588),
            new Location(44.296026, -88.527575),
            new Location(44.300326, -88.536758),
            new Location(44.287425, -88.537102),
            new Location(44.273107, -88.537273),
            new Location(44.258294, -88.537273),
            new Location(44.249318, -88.537273),
            new Location(44.246429, -88.537874),
            new Location(44.243969, -88.539333),
            new Location(44.244031, -88.526287),
            new Location(44.244092, -88.496847),
            new Location(44.250333, -88.496761),
            new Location(44.254114, -88.496718),
            new Location(44.262044, -88.496675),
            new Location(44.270249, -88.496461),
            new Location(44.281342, -88.496246),
            new Location(44.290681, -88.496118),
            new Location(44.301984, -88.496203),
            new Location(44.309324, -88.496246),
            new Location(44.309662, -88.516245)
        };

        /// <summary>
        /// Calculates the standard garbage day (wednesday - friday) for the given location.
        /// </summary>
        public static DayOfWeek CalculateGarbageDay(Location location)
        {
            if (IsPointInPolygon(WEDNESDAY, location))
                return DayOfWeek.Wednesday;
            else if (IsPointInPolygon(FRIDAY, location))
                return DayOfWeek.Friday;

            return DayOfWeek.Thursday;
        }

        /// <summary>
        /// Calculates all garbage collection events for the given collection day between the start date and end date
        /// </summary>
        public static List<GarbageCollectionEvent> CalculateCollectionEvents(DayOfWeek garbageDay, DateTime startDate, DateTime endDate)
        {
            var result = new List<GarbageCollectionEvent>();

            for (var curDate = startDate.Date; curDate <= endDate.Date; curDate = curDate.AddDays(1))
            {
                var collectionTypesToday = CollectionTypesForDay(curDate, garbageDay);

                if (collectionTypesToday.Any())
                {
                    result.AddRange(collectionTypesToday.Select(cType => new GarbageCollectionEvent
                    {
                        CollectionDate = curDate,
                        CollectionType = cType
                    }));
                }
            }

            return result;
        }

        /// <summary>
        /// Returns all of the collection types that will happen on the given day for the given collection zone
        /// </summary>
        public static List<GarbageCollectionType> CollectionTypesForDay(DateTime date, DayOfWeek garbageDay)
        {
            date = date.Date;
            var result = new List<GarbageCollectionType>();
            var holiday = HOLIDAYS[date.Year].SingleOrDefault(x => Math.Abs((date - x).TotalDays) < 3);

            if (holiday != default(DateTime) && holiday.DayOfWeek <= garbageDay)
                garbageDay++;

            if (date.DayOfWeek == garbageDay)
            {
                result.Add(GarbageCollectionType.Trash);
                
                var recyclingPhaseStart = new DateTime(2015, 1, 7);
                var daysSinceRecyclingPhaseStart = (int)Math.Round((date - recyclingPhaseStart).TotalDays);
                var weeksSinceRecyclingPhaseStart = daysSinceRecyclingPhaseStart / 7;

                if (weeksSinceRecyclingPhaseStart % 2 == 0)
                    result.Add(GarbageCollectionType.Recycling);
            }

            return result;
        }

        /// <summary>
        /// Tests that a point is within the given polygon
        /// </summary>
        private static bool IsPointInPolygon(List<Location> poly, Location point)
        {
            int i, j;
            bool c = false;
            for (i = 0, j = poly.Count - 1; i < poly.Count; j = i++)
            {
                if ((((poly[i].Latitude <= point.Latitude) && (point.Latitude < poly[j].Latitude))
                        || ((poly[j].Latitude <= point.Latitude) && (point.Latitude < poly[i].Latitude)))
                        && (point.Longitude < ((poly[j].Longitude - poly[i].Longitude) * (point.Latitude - poly[i].Latitude)
                            / (poly[j].Latitude - poly[i].Latitude)) + poly[i].Longitude))

                    c = !c;
            }

            return c;
        }
    }
}
