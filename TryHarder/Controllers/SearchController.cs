using System;
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
            QueryViewModel model = new QueryViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Results(QueryViewModel model)
        {
            //get name of selected region based on value from dropdown
            string SelectedRegionName = RegionConstants.RegionsList[model.SelectedRegionId].Name;
            return RedirectToAction("Results", new { SummonerName = model.SummonerName, Region = SelectedRegionName });
        }

        [HttpGet]
        public ActionResult Results(string SummonerName, string Region)
        {
            QueryViewModel searchModel = new QueryViewModel();
            //validate summoner name is entered and region exists
            if(!string.IsNullOrWhiteSpace(SummonerName) && QueryViewModel.Regions.Any(i => i.Text.Equals(Region)))
            {
               
            } else
            {
                // region not found error
            }

            //if something breaks, go home
            return RedirectToAction("Index");
        }
    }
}