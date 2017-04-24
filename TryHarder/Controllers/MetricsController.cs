using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TryHarder.Models;

namespace TryHarder.Controllers
{
    public class MetricsController : Controller
    {
        // GET: Metrics
        public ActionResult Index()
        {
            string path = Server.MapPath("~/content/sample.xml");
            XDocument SummonerMetrics = XDocument.Load(path);

            SummonerModel Summoner = new SummonerModel(SummonerMetrics.Root.Element("Summoner"));
            return View(Summoner);
        }

        // GET: Metrics/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Metrics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Metrics/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Metrics/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Metrics/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Metrics/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Metrics/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
