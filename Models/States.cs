using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeCarriers.Models
{
    public class States
    {
        public int StateID { get; set; }
        [Display(Name = "State")]
        public string StateName { get; set; }
        [Display(Name = "Abbrev.")]
        public string StateAbbrev { get; set; }
        
    }//END CLASS STATES
}