using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryHarder.Helpers
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

    public static class RegionConstants
    {
        public static List<Region> RegionsList = new List<Region>
        {
            new Region(0, "NA"),
            new Region(1, "EUW"),
            new Region(2, "EUNE"),
            new Region(3, "LAN"),
            new Region(4, "LAS"),
            new Region(5, "BR"),
            new Region(6, "RU"),
            new Region(7, "TR"),
            new Region(8, "OCE"),
            new Region(9, "KR"),
            new Region(10, "JP")
        };
    }
}