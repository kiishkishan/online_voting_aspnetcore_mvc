using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;


namespace OnlineVotingSystem.Controllers
{
    public class ElectionMainController : Controller
    {
        static string ID;
        //
        // GET: /ElectionMain/
        SystemDbConfiguration Db = new SystemDbConfiguration();
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Election/Details/{id}

        public ActionResult ViewDetails(string id)
        {
            if (id == null)
                id = ID;
            ID = id;
            var elections = Db.Elections.Single(r => r.ElectionId == id);

            return View(elections);
        }

        //
        // GET: /ElectionMain/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ElectionMain/Create

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

        //
        // GET: /ElectionMain/Edit/{id}

        public ActionResult Edit(string id)
        {
            var candidate = Db.Candidates.Single(r => r.CandidateId == id);
            return View(candidate);
        }

        //
        // POST: /ElectionMain/Edit/{id}

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                var election = Db.Elections.Single(r => r.ElectionId == id);
                TryUpdateModel(election);
                // TODO: Add update logic here
                Db.SaveChanges();
                return RedirectToAction("Election", new { ID = election.ElectionId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ElectionMain/Delete/{id}

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ElectionMain/Delete/{id}

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
