using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineVotingSystem.Models
{
    public class SystemDbConfiguration : DbContext
    {
        public DbSet<Election> Elections{get;set;}
        public DbSet<Voter> Voters{get;set;}
        public DbSet<Candidate> Candidates{get; set;}
        public DbSet<BallotPaper> ballotPapers { get; set; }
        public DbSet<VoteCast> voteCasts { get; set; }
        public DbSet<VoteCount> voteCounts { get; set; }

    }
}