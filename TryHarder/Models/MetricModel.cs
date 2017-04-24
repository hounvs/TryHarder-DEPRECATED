using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TryHarder.Models
{
    public class MetricModel : NamedModel
    {
        #region Properties
        /// <summary>
        /// What category the metric falls under.
        /// Is not on every Metric.
        /// </summary>
        public string Category { get; set; }
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
        /// <summary>
        /// Default initializer
        /// </summary>
        public MetricModel()
        {
            Category = string.Empty;
            Grain = string.Empty;

            Bin = 0;
            Games = 0;
            Pop = 0;

            Percent = -1.000000;
            Value = -1.000000;
        }

        /// <summary>
        /// Converts a MetricModel XElement into a MetricModel
        /// </summary>
        /// <param name="metricElement">XElement to convert</param>
        /// <returns>MetricModel with properties set</returns>
        public MetricModel(XElement metricNode)
        {
            try
            {
                int bin, games, pop;
                double percent, value;

                // Set strings
                Category = (string)metricNode.Attribute("Category");
                Name = (string)metricNode.Attribute("Name");
                Grain = (string)metricNode.Attribute("Grain");

                // Parse ints
                int.TryParse((string)metricNode.Attribute("Bin"), out bin);
                int.TryParse((string)metricNode.Attribute("Games"), out games);
                int.TryParse((string)metricNode.Attribute("Pop"), out pop);

                // Parse doubles
                double.TryParse((string)metricNode.Attribute("Percent"), out percent);
                double.TryParse((string)metricNode.Attribute("Value"), out value);

                // Set numerics
                Bin = bin;
                Games = games;
                Pop = pop;
                Percent = percent;
                Value = value;
            }
            catch(Exception ex)
            {
                //TODO
                Category = string.Empty;
                Grain = string.Empty;

                Bin = 0;
                Games = 0;
                Pop = 0;

                Percent = -1.000000;
                Value = -1.000000;
            }
        }
        #endregion

        #region Methods
        
        #endregion
    }
}