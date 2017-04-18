using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryHarder.Models
{
    public class ChampionModel
    {
        /// <summary>
        /// The name of the Champion.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the Champion.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The list of Role Groups for the Champion.
        /// </summary>
        public IEnumerable<RoleGroupModel> RoleGroups;
    }
}