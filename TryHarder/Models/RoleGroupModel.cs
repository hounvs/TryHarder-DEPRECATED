using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryHarder.Models
{
    public class RoleGroupModel
    {
        /// <summary>
        /// Name of the Role Group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The list of Time Buckets for the Role Group;
        /// </summary>
        public IEnumerable<TimeBucketModel> TimeBuckets;
    }
}