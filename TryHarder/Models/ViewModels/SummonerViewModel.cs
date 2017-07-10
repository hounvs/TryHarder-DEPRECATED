using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryHarder.Models.ViewModels
{
    public class SummonerViewModel
    {
        private ChampionModel selectedChampion;
        private RoleGroupModel selectedRoleGroup;
        private TimeBucketModel selectedTimeBucket;
        private MetricModel selectedMetric;
        private SummonerModel summoner;

        public SummonerViewModel()
        {
            summoner = new SummonerModel();
        }

        public SummonerViewModel(SummonerModel summoner)
        {
            this.summoner = summoner;
        }

        public SummonerModel Summoner
        {
            get { return summoner; }
            set { summoner = value; }
        }

        public ChampionModel SelectedChampion
        {
            get { return selectedChampion; }
            set { selectedChampion = value; }
        }

        public RoleGroupModel SelectedRoleGroup
        {
            get { return selectedRoleGroup; }
            set { selectedRoleGroup = value; }
        }

        public TimeBucketModel SelectedTimeBucket
        {
            get { return selectedTimeBucket; }
            set { selectedTimeBucket = value; }
        }

        public MetricModel SelectedMetric
        {
            get { return selectedMetric; }
            set { selectedMetric = value; }
        }
    }
}