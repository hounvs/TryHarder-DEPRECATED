using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TryHarder.Models
{
    public class RoleGroupModel : NamedModel
    {
        #region Properties
        /// <summary>
        /// The list of Time Buckets for the Role Group;
        /// </summary>
        public IEnumerable<TimeBucketModel> TimeBuckets;
        #endregion

        #region Initializers
        public RoleGroupModel()
        {
            TimeBuckets = new List<TimeBucketModel>();
        }

        public RoleGroupModel(XElement roleGroupNode)
        {
            List<TimeBucketModel> timeBucketModels = new List<TimeBucketModel>();

            try
            {
                Name = (string)roleGroupNode.Attribute("Name");

                foreach (XElement timeBucket in roleGroupNode.Element("TimeBuckets").Elements())
                {
                    timeBucketModels.Add(new TimeBucketModel(timeBucket));
                }

                TimeBuckets = timeBucketModels;
            }
            catch (Exception ex)
            {
                // TODO
                TimeBuckets = new List<TimeBucketModel>();
            }
        }
        #endregion
    }
}