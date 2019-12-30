using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.Models
{
    public class VoteCount
    {
        public string ElectionId { get; set; }
        public string CandidateId { get; set; }
        public long Votes { get; set; }
    }
}