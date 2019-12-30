using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;


namespace OnlineVotingSystem.Controllers
{


    public class VoteCastController : Controller
    {
        static string ID;
        //
        // GET: /VoteCast/
        SystemDbConfiguration Db = new SystemDbConfiguration();
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /VoteCast/Details/{id}

        public ActionResult ViewDetails(string id)
        {
            if (id == null)
                id = ID;
            ID = id;
            var votecast = Db.voteCasts.Single(r => r.VoterId == id);

            return View(votecast);
        }

        /*POST: /VoteCast/CasteVote*/
        [HttpPost]
        public ActionResult CastVote(string VoterID, string CandidateID, string ElectionID)
        {
          
            var voter = Db.Voters
           .Single(r => r.VoterId == VoterID & r.Voted == false);
            voter.Voted = true;
            var votercount = Db.voteCounts
            .Single(r => r.CandidateId == CandidateID);
            votercount.Votes = votercount.Votes + 1;

            
            
           

      
            Db.SaveChanges();
          


            return View("Voted");
        }



        //
        // GET: /VoteCast/GetbyElectionID/{id} 


        public ActionResult GetByElectionID(string id)
        {
            var candidate = Db.ballotPapers.Single(r => r.ElectionId == id);
            return View(candidate);
        }

        


    }
}
