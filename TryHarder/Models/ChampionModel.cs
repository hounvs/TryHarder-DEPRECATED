using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TryHarder.Models
{
    public class ChampionModel : NamedModel
    {
        #region Properties
        /// <summary>
        /// The list of Role Groups for the Champion.
        /// </summary>
        public IEnumerable<RoleGroupModel> RoleGroups;
        #endregion

        #region Initializers
        public ChampionModel()
        {
            RoleGroups = new List<RoleGroupModel>();
        }

        public ChampionModel(XElement championNode)
        {
            List<RoleGroupModel> roleGroupModels = new List<RoleGroupModel>();

            try
            {
                Name = (string)championNode.Attribute("Name");

                int champID = -1;
                int.TryParse((string)championNode.Attribute("ID"), out champID);
                ID = champID;

                foreach (XElement roleGroup in championNode.Element("RoleGroups").Elements())
                {
                    roleGroupModels.Add(new RoleGroupModel(roleGroup));
                }

                RoleGroups = roleGroupModels;
            }
            catch (Exception ex)
            {
                // TODO
                Name = DefaultName;
                ID = DefaultID;
                RoleGroups = new List<RoleGroupModel>();
            }
        }
        #endregion
    }
}