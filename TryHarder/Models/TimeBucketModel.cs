using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TryHarder.Models
{
    public class TimeBucketModel : NamedModel
    {
        #region Properties
        /// <summary>
        /// The list of Metrics for the Time Bucket;
        /// </summary>
        public IEnumerable<MetricModel> Metrics;
        #endregion

        #region Initializers
        public TimeBucketModel()
        {
            Metrics = new List<MetricModel>();
        }

        public TimeBucketModel(XElement timeBucketNode)
        {
            List<MetricModel> metricModels = new List<MetricModel>();

            try
            {
                Name = (string)timeBucketNode.Attribute("Name");

                foreach (XElement metricElement in timeBucketNode.Element("Metrics").Elements())
                {
                    metricModels.Add(new MetricModel(metricElement));
                }

                Metrics = metricModels;
            }
            catch (Exception ex)
            {
                // TODO
                Metrics = new List<MetricModel>();
            }
        }
        #endregion
    }
}