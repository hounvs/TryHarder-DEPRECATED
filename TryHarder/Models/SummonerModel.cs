using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryHarder.Models
{
    public class SummonerModel
    {
        /// <summary>
        /// The name of the Summoner.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the Summoner.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The list of Champions for the Summoner.
        /// </summary>
        public IEnumerable<ChampionModel> Champions;
    }
}