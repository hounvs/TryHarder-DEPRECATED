using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace TryHarder.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class SearchViewModel
    {
        public List<Region> RegionsList = new List<Region>
        {
            new Region(0, "North America"),
            new Region(1, "EU West"),
            new Region(2, "EU Nordic & East"),
            new Region(3, "Latin America North"),
            new Region(4, "Latin America South"),
            new Region(5, "Brazil"),
            new Region(6, "Russia"),
            new Region(7, "Turkey"),
            new Region(8, "Oceania"),
            new Region(9, "Republic of Korea"),
            new Region(10, "Japan")
        };

        [Display(Name = "Region")]
        public int SelectedRegionId { get; set; }

        [Display(Name = "Summoner Name")]
        public string SummonerName { get; set; }
        
        public IEnumerable<SelectListItem> Regions
        {
            get
            {
                var allRegions = RegionsList.Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Name
                });
                return allRegions;
            }
        }
    }
}

/*
[
    {
        "region_tag": "na1",
        "locales": ["en_US"],
        "name": "North America",
        "hostname": "prod.na1.lol.riotgames.com",
        "slug": "na"
    },
    {
        "region_tag": "eu",
        "locales": [
            "en_GB",
            "fr_FR",
            "it_IT",
            "es_ES",
            "de_DE"
        ],
        "name": "EU West",
        "hostname": "prod.euw1.lol.riotgames.com",
        "slug": "euw"
    },
    {
        "region_tag": "eun1",
        "locales": [
            "en_PL",
            "hu_HU",
            "pl_PL",
            "ro_RO",
            "cs_CZ",
            "el_GR"
        ],
        "name": "EU Nordic & East",
        "hostname": "prod.eun1.lol.riotgames.com",
        "slug": "eune"
    },
    {
        "region_tag": "la1",
        "locales": ["es_MX"],
        "name": "Latin America North",
        "hostname": "prod.la1.lol.riotgames.com",
        "slug": "lan"
    },
    {
        "region_tag": "la2",
        "locales": ["es_MX"],
        "name": "Latin America South",
        "hostname": "prod.la2.lol.riotgames.com",
        "slug": "las"
    },
    {
        "region_tag": "br1",
        "locales": ["pt_BR"],
        "name": "Brazil",
        "hostname": "prod.br.lol.riotgames.com",
        "slug": "br"
    },
    {
        "region_tag": "ru1",
        "locales": ["ru_RU"],
        "name": "Russia",
        "hostname": "prod.ru.lol.riotgames.com",
        "slug": "ru"
    },
    {
        "region_tag": "tr1",
        "locales": ["tr_TR"],
        "name": "Turkey",
        "hostname": "prod.tr.lol.riotgames.com",
        "slug": "tr"
    },
    {
        "region_tag": "oc1",
        "locales": ["en_AU"],
        "name": "Oceania",
        "hostname": "prod.oc1.lol.riotgames.com",
        "slug": "oce"
    },
    {
        "region_tag": "kr1",
        "locales": ["ko_KR"],
        "name": "Republic of Korea",
        "hostname": "prod.kr.lol.riotgames.com",
        "slug": "kr"
    },
    {
        "region_tag": "jp1",
        "locales": ["ja_JP"],
        "name": "Japan",
        "hostname": "prod.jp1.lol.riotgames.com",
        "slug": "jp"
    }
]
    */
