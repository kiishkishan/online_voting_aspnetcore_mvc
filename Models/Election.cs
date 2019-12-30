using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineVotingSystem.Models
{
    public class Election
    {   
        
        public string ElectionId { get; set; }
        public string ElectionName { get; set; }
        public string ElectionType { get; set; }



     
    }
}