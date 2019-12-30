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
        // GET: /VoterMain/Details/5

        public ActionResult Profile(string id)
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
        // GET: /VoterMain/Edit/5
 
        public ActionResult Edit(string id)
        {
            var voter = Db.Voters.Single(r => r.VoterId == id);

            return View(voter);
        }

        //
        // POST: /VoterMain/Edit/5

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
        // GET: /VoterMain/Delete/5

        public ActionResult Vote()
        {
            try
            {
                var voter = Db.Voters.Single(r => r.VoterId == ID && r.Voted==0);
                var model = Db;
                ViewBag.items = new[] { "ElectionID", "VoterID", "CandidateID", "Status" };
                return View(model);
            }
            catch
            {

                return View("Voted");
            }
        }

        [HttpPost]
        public ActionResult Vote(string ElectionID, string VoterID, string CandidateID, bool Status)
        {
            var vote = Db.Candidates
            .Single(r=>r.CandidateId==CandidateID);
            vote.Votes = vote.Votes + 1;
            var voted = Db.Voters
            .Single(r => r.VoterId == VoterID);
            voted.Voted = voted.Voted = true;
            
            return View("Voted");
        }



       
       
}
