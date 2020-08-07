using System;
using System.Collections.Generic;
using GreenvilleWiApi.Data.GarbageCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreenvilleWiApi.Test
{
    /// <summary>
    /// Garbage collection calculation unit tests
    /// </summary>
    [TestClass]
    public class GarbageCollectionTests
    {
        /// <summary>
        /// Tests that the correct garbage collection types are returned from the calculator
        /// </summary>
        [TestMethod]
        public void CorrectGarbageCollectionTypesReturned()
        {
            // Test normal collection days
            CollectionAssert.AreEqual(new List<GarbageCollectionType> { GarbageCollectionType.Trash }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 7, 3), DayOfWeek.Friday));
            CollectionAssert.AreEqual(new List<GarbageCollectionType> { GarbageCollectionType.Trash, GarbageCollectionType.Recycling }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 7, 10), DayOfWeek.Friday));

            // Test wrong collection days
            CollectionAssert.AreEqual(new List<GarbageCollectionType> { }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 7, 3), DayOfWeek.Wednesday));
            CollectionAssert.AreEqual(new List<GarbageCollectionType> { }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 7, 10), DayOfWeek.Wednesday));

            // Test holiday collection days
            CollectionAssert.AreEqual(new List<GarbageCollectionType> { GarbageCollectionType.Trash, GarbageCollectionType.Recycling }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 11, 25), DayOfWeek.Wednesday));
            CollectionAssert.AreEqual(new List<GarbageCollectionType> { GarbageCollectionType.Trash, GarbageCollectionType.Recycling }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 11, 28), DayOfWeek.Friday));
            CollectionAssert.AreEqual(new List<GarbageCollectionType> { }, GarbageDayCalculator.CollectionTypesForDay(new DateTime(2015, 11, 27), DayOfWeek.Friday));
        }

        /// <summary>
        /// Tests that the correct events are returned from the calculator
        /// </summary>
        [TestMethod]
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
            CollectionAssert.AreEqual(november2015FridayEvents, result);
        }
    }
}
