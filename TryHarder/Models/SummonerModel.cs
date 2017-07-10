using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TryHarder.Models
{
    public class SummonerModel : NamedModel
    {
        #region Properties
        /// <summary>
        /// The list of Champions for the Summoner.
        /// </summary>
        public IEnumerable<ChampionModel> Champions;
        #endregion

        #region Initializers
        public SummonerModel()
        {
            Champions = new List<ChampionModel>();
        }

        public SummonerModel(XElement summonerNode)
        {
            List<ChampionModel> championModels = new List<ChampionModel>();

            try
            {
                Name = (string)summonerNode.Attribute("Name");

                int champID = -1;
                int.TryParse((string)summonerNode.Attribute("ID"), out champID);
                ID = champID;

                foreach (XElement champion in summonerNode.Element("Champions").Elements())
                {
                    championModels.Add(new ChampionModel(champion));
                }

                Champions = championModels;
            }
            catch (Exception ex)
            {
                // TODO
                Champions = new List<ChampionModel>();
            }
        }
        #endregion
    }
}