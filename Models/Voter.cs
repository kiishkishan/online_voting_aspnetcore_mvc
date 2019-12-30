using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class Voter
    {
       
        public string  VoterId { get; set; }
      
        public string Name { get; set; }
        public string Nic_no { get; set; }
        public string District { get; set; }
        public string PollingDivision { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        public bool Voted { get; set; }
    }
}