using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.Models
{
    public class VoteCast
    {
        public string VoterId { get; set; }
        public string ElectionId { get; set; }
        public string CandidateId { get; set; }
    }
}