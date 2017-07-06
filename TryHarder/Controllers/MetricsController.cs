using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TryHarder.Models;
using TryHarder.Models.ViewModels;

namespace TryHarder.Controllers
{
    public class MetricsController : Controller
    {
        // GET: Metrics
        public ActionResult Index()
        {            
            return View(GetSummonerViewModel());
        }

        // GET: Metrics/Champion/5
        public ActionResult Champion(string id)
        {
            SummonerViewModel model = GetSummonerViewModel();

            int SelectedChampionId;

            // No SelectedChampion, load all stats
            if (string.IsNullOrEmpty(id))
            {
                //// TODO: Redirect to another action to show overall stats
                model.SelectedChampion = model.Summoner.Champions.FirstOrDefault();
            }
            // Parse SelectedChampion as an ID
            else if (int.TryParse(id, out SelectedChampionId))
            {
                model.SelectedChampion = model.Summoner.Champions.FirstOrDefault(c => c.ID == SelectedChampionId);
            }
            // Parse SelectedChampion as a champ name
            else
            {
                id = id.ToLowerInvariant();
                model.SelectedChampion = model.Summoner.Champions.FirstOrDefault(c => c.Name.ToLowerInvariant() == id);
            }

            return View(model);
        }

        //public ActionResult Champion(string Champion)
        //{
        //    return RedirectToAction("Champion", int.Parse(Champion));
        //}

        private SummonerViewModel GetSummonerViewModel()
        {
            if (Session["Model"] == null)
            {
                SummonerViewModel summonerViewModel = new SummonerViewModel();

                try
                {
                    // Load XML via database
                    XDocument SummonerMetrics = GetOnlineMetrics("GundayMonday");

                    // Load XML via local file
                    //XDocument SummonerMetrics = GetOfflineMetrics("~/content/sample.xml");

                    summonerViewModel.Summoner = new SummonerModel(SummonerMetrics.Root.Element("Summoner"));
                }
                catch(Exception ex)
                {
                    // TODO: Something useful
                    summonerViewModel.Summoner = new SummonerModel();
                }
                finally
                {
                    HttpContext.Session.Add("Model", summonerViewModel);
                }
            }

            return Session["Model"] as SummonerViewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private XDocument GetOnlineMetrics(string summonerName)
        {
            XDocument SummonerMetrics = new XDocument();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LoLDb"].ConnectionString))
            using (var command = new SqlCommand("[LoL].[SummonerMetrics_XML]", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Summoner", summonerName));
                ////command.Parameters.Add(new SqlParameter("@Champion", custId));
                ////command.Parameters.Add(new SqlParameter("@RoleGroup", custId));

                conn.Open();

                using (var response = command.ExecuteXmlReader())
                {
                    while (response.Read())
                    {
                        SummonerMetrics = XDocument.Load(response);
                    }
                }
            }

            return SummonerMetrics;
        }

        private XDocument GetOfflineMetrics(string XMLPath)
        {
            string path = Server.MapPath(XMLPath);

            return XDocument.Load(path);
        }
    }
}
