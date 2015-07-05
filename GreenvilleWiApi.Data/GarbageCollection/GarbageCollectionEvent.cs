using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GreenvilleWiApi.Data.GarbageCollection
{
    /// <summary>
    /// A garbage collection event
    /// </summary>
    public class GarbageCollectionEvent
    {
        /// <summary>
        /// Gets or sets the type of collection
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GarbageCollectionType CollectionType { get; set; }

        /// <summary>
        /// Gets or sets the date of collection
        /// </summary>
        public DateTime CollectionDate { get; set; }

        /// <summary>
        /// Equals implementation
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = obj as GarbageCollectionEvent;

            if (other == null)
                return false;

            return
                this.CollectionType == other.CollectionType &&
                this.CollectionDate == other.CollectionDate;
        }

        /// <summary>
        /// GetHashCode implementation
        /// </summary>
        public override int GetHashCode()
        {
            return (this.CollectionDate.ToString() + this.CollectionType.ToString()).GetHashCode();
        }
    }
}