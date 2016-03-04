﻿using numl.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numl.Serialization.Supervised
{
    /// <summary>
    /// Implements a Summary object serializer.
    /// </summary>
    public class SummarySerializer : JsonSerializer
    {
        /// <summary>
        /// Returns True if the specified Type can be converted to a Summmary object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool CanConvert(Type type)
        {
            return typeof(Summary).IsAssignableFrom(type);
        }

        /// <summary>
        /// Creates a default Summary object.
        /// </summary>
        /// <returns></returns>
        public override object Create()
        {
            return new Summary();
        }

        /// <summary>
        /// Deserializes a Summary object from the given stream.
        /// </summary>
        /// <param name="reader">A JSON Reader object.</param>
        /// <returns></returns>
        public override object Read(JsonReader reader)
        {
            if (reader.IsNull()) return null;
            else
            {
                var summary = (Summary)Create();
                summary.Average = reader.ReadVector();
                summary.Minimum = reader.ReadVector();
                summary.Median = reader.ReadVector();
                summary.Maximum = reader.ReadVector();
                summary.StandardDeviation = reader.ReadVector();
                return summary;
            }
        }

        /// <summary>
        /// Serializes the given Summary object to the given stream.
        /// </summary>
        /// <param name="writer">A JSON Writer object.</param>
        /// <param name="value">A Summary object.</param>
        public override void Write(JsonWriter writer, object value)
        {
            if (value == null) writer.WriteNull();
            else
            {
                var summary = (Summary)value;
                writer.WriteProperty(nameof(Summary.Average), summary.Average);
                writer.WriteProperty(nameof(Summary.Minimum), summary.Minimum);
                writer.WriteProperty(nameof(Summary.Median), summary.Median);
                writer.WriteProperty(nameof(Summary.Maximum), summary.Maximum);
                writer.WriteProperty(nameof(Summary.StandardDeviation), summary.StandardDeviation);
            }
        }
    }
}
