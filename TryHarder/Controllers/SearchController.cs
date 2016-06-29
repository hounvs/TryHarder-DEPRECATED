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
        private LoLDb db = new LoLDb();

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
            SearchViewModel searchModel = new SearchViewModel();
            //validate summoner name is entered and region exists
            if(!String.IsNullOrWhiteSpace(SummonerName) && searchModel.Regions.Any(i => i.Text.Equals(Region)))
            {
                // get db row where db row name equals entered name, case insensitive
                //IQueryable<Summoner> Summoner = db.Summoners.Where(x => x.Summoner1.ToLower().Equals(SummonerName.ToLower()));
                long summonerId = long.Parse(SummonerName);
                IQueryable<Summoner> Summoner = db.Summoners.Where(x => x.SummonerID == summonerId);

                if (Summoner.Any())
                {
                    ResultsViewModel resultsModel = new ResultsViewModel();
                    resultsModel.summoner = Summoner.FirstOrDefault();

                    IQueryable<SummonerMatchQuarter> matchQuarters = db.SummonerMatchQuarters.Where(x => x.SummonerID == summonerId).Take(20);
                    resultsModel.matchQuarters = matchQuarters.ToList();

                    return View(resultsModel);
                } else
                {
                    // summoner not found error
                }
            } else
            {
                // region not found error
            }

            //if something breaks, go home
            return RedirectToAction("Index");
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