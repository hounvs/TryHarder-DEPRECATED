using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryHarder.Models
{
    public class TimeBucketModel
    {
        /// <summary>
        /// Name of the Time Bucket.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The list of Metrics for the Time Bucket;
        /// </summary>
        public IEnumerable<MetricModel> Metrics;
    }
}