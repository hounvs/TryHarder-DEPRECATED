using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TryHarder.Models;

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
            return RedirectToAction("Results", new { SummonerName = model.SummonerName, SelectedRegionId = model.SelectedRegionId});
        }

        [HttpGet]
        public ActionResult Results(string SummonerName, int SelectedRegionId)
        {
            SearchViewModel model = new SearchViewModel();
            model.SummonerName = SummonerName;
            model.SelectedRegionId = SelectedRegionId;

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