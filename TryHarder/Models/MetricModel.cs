using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryHarder.Models
{
    public class MetricModel
    {
        #region Properties
        /// <summary>
        /// What category the metric falls under.
        /// Is not on every Metric.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Name of the Metric.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The grain level that the Metric applies to.
        /// </summary>
        public string Grain { get; set; }

        /// <summary>
        /// How many discrete, evenly spaced slices for the Metric.
        /// </summary>
        public int Bin { get; set; }
        /// <summary>
        /// Population of the histogram. Number of instances for this Metric in our dataset.
        /// </summary>
        public int Games { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Pop { get; set; }

        /// <summary>
        /// -1.0000000
        /// </summary>
        public double Percent { get; set; }
        /// <summary>
        /// Numeric value of the Metric.
        /// </summary>
        public double Value { get; set; }
        #endregion

        #region Initializers
        public MetricModel()
        {
            Category = string.Empty;
            Name = string.Empty;
            Grain = string.Empty;

            Bin = 0;
            Games = 0;
            Pop = 0;

            Percent = -1.000000;
            Value = -1.000000;
        }
        #endregion

        #region Methods

        #endregion
    }
}