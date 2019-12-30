﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class Candidate
    {

        public string CandidateId { get; set; }
     
        public string Party { get; set; }
     
        public int Votes { get; set; }
    }
}