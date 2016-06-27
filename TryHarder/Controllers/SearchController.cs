﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TryHarder.Models;
using TryHarder.Helpers;

namespace TryHarder.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            SearchViewModel model = new SearchViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Results(SearchViewModel model)
        {
            //get name of selected region based on value from dropdown
            string SelectedRegionName = RegionConstants.RegionsList[model.SelectedRegionId].Name;
            return RedirectToAction("Results", new { SummonerName = model.SummonerName, Region = SelectedRegionName });
        }

        [HttpGet]
        public ActionResult Results(string SummonerName, string Region)
        {
            SearchViewModel model = new SearchViewModel();
            model.SummonerName = SummonerName;
            model.RegionName = Region;

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}