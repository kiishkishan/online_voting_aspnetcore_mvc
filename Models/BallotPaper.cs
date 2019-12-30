using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.Models
{
    public class BallotPaper
    {

      /*  public List<Election> elections { get; set; }
        public List<Candidate> candidates { get; set; }*/
        public string ElectionId { get; set; }
        public string CandidateId { get; set; }

        public string ElectionDate { get; set; }
    }
}