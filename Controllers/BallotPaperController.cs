using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;


namespace OnlineVotingSystem.Controllers
{

    public class BallotPaperController : Controller
    {
        static string ID;
        //
        // GET: /BallotPaper/
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
        // GET: /BallotPaper/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BallotPaper/Create

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
        // GET: /BallotPaper/GetbyElectionID/{id} 


        public ActionResult GetByElectionID(string id)
        {
            var candidate = Db.ballotPapers.Single(r => r.ElectionId == id);
            return View(candidate);
        }

        //
        // POST: /BallotPaper/Edit/{id} 

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                var ballotPaper = Db.ballotPapers.Single(r => r.ElectionId == id);
                TryUpdateModel(ballotPaper);
                // TODO: Add update logic here
                Db.SaveChanges();
                return RedirectToAction("Election", new { ID = ballotPaper.ElectionId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BallotPaper/Delete/{id}

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /BallotPaper/Delete/{id}

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
