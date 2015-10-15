using System;
using System.Collections.Generic;
using GreenvilleWiApi.Data.GarbageCollection;
using Xunit;

namespace GreenvilleWiApi.Test
{
    /// <summary>
    /// Garbage collection calculation unit tests
    /// </summary>
    public class GarbageCollectionTests
    {
        /// <summary>
        /// Tests that the correct garbage collection types are returned from the calculator
        /// </summary>
        [Fact]
        public void CorrectGarbageCollectionTypesReturned()
        {
            // Test normal collection days
            Assert.Equal(new List<GarbageCollectionType> { GarbageCollectionType.Trash }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 7, 3), DayOfWeek.Friday));
            Assert.Equal(new List<GarbageCollectionType> { GarbageCollectionType.Trash, GarbageCollectionType.Recycling }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 7, 10), DayOfWeek.Friday));

            // Test wrong collection days
            Assert.Equal(new List<GarbageCollectionType> { }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 7, 3), DayOfWeek.Wednesday));
            Assert.Equal(new List<GarbageCollectionType> { }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 7, 10), DayOfWeek.Wednesday));

            // Test holiday collection days
            Assert.Equal(new List<GarbageCollectionType> { GarbageCollectionType.Trash, GarbageCollectionType.Recycling }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 11, 25), DayOfWeek.Wednesday));
            Assert.Equal(new List<GarbageCollectionType> { GarbageCollectionType.Trash, GarbageCollectionType.Recycling }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 11, 28), DayOfWeek.Friday));
            Assert.Equal(new List<GarbageCollectionType> { }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 11, 27), DayOfWeek.Friday));
        }

        /// <summary>
        /// Tests that the correct events are returned from the calculator
        /// </summary>
        [Fact]
        public void CorrectGarbageCollectionEventsReturned()
        {
            var november2015FridayEvents = new List<GarbageCollectionEvent>
            {
                new GarbageCollectionEvent { CollectionType = GarbageCollectionType.Trash, CollectionDate = new DateTime(2015, 11, 6) },
                new GarbageCollectionEvent { CollectionType = GarbageCollectionType.Trash, CollectionDate = new DateTime(2015, 11, 13) },
                new GarbageCollectionEvent { CollectionType = GarbageCollectionType.Recycling, CollectionDate = new DateTime(2015, 11, 13) },
                new GarbageCollectionEvent { CollectionType = GarbageCollectionType.Trash, CollectionDate = new DateTime(2015, 11, 20) },
                new GarbageCollectionEvent { CollectionType = GarbageCollectionType.Trash, CollectionDate = new DateTime(2015, 11, 28) },
                new GarbageCollectionEvent { CollectionType = GarbageCollectionType.Recycling, CollectionDate = new DateTime(2015, 11, 28) },
            };

            var result = GarbageDayCalculator.CalculateCollectionEvents(DayOfWeek.Friday, new DateTime(2015, 11, 1), new DateTime(2015, 11, 30));
            Assert.Equal(november2015FridayEvents, result);
        }
    }
}
