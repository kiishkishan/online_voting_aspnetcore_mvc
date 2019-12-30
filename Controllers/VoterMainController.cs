using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;

namespace OnlineVotingSystem.Controllers
{
    public class VoterMainController : Controller
    {
        //
        // GET: /VoterMain/
        SystemDbConfiguration Db = new SystemDbConfiguration();
        static string ID;
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /VoterMain/Details/{id}

        public ActionResult VoterProfile(string id)
        {
            try
            {
                var voter = Db.Voters.Single(r => r.VoterId == id);
                ID = id;
                return View(voter);
            }
            catch
            {
                return RedirectToAction("Profile", new { id = ID });
            }
        }


        //
        // GET: /VoterMain/Edit/{id}

        public ActionResult Edit(string id)
        {
            var voter = Db.Voters.Single(r => r.VoterId == id);

            return View(voter);
        }

        //
        // POST: /VoterMain/Edit/{id}

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var voter = Db.Voters.Single(r => r.VoterId == id);
                TryUpdateModel(voter);
                Db.SaveChanges();
                return RedirectToAction("Profile", new { ID = voter.VoterId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /VoterMain/ResetStatus/{id}  * for new election

        public ActionResult ResetVoteStatus()
        {
            try
            {
                var voter = Db.Voters.Single(r => r.VoterId == ID && r.Voted == false);
                var model = Db;
                return View(model);
            }
            catch
            {

                return View("Voted");
            }
        }






    }
}