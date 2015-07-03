using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenvilleWiApi.WebApi.Models
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
    /// A garbage collection event
    /// </summary>
    public class GarbageCollectionModel
    {
        /// <summary>
        /// Gets or sets the type of collection
        /// </summary>
        public GarbageCollectionType CollectionType { get; set; }

        /// <summary>
        /// Gets or sets the date of collection
        /// </summary>
        public DateTime CollectionDate { get; set; }
    }
}