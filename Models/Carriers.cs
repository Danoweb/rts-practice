using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeCarriers.Models
{
    public class Carriers
    {
        public int CarrierID { get; set; }
        [StringLength(50, ErrorMessage = "MC Number cannot be longer than 50 characters.")]
        [Display(Name = "MC Number")]
        public string MCNumber { get; set; }
        
        [Display(Name = "DOT Number")]
        public int DOTNumber { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [StringLength(200, ErrorMessage = "City cannot be longer than 200 characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public int StateID { get; set; }

        [StringLength(20, ErrorMessage = "Zip cannot be longer than 20 characters.")]
        [Display(Name = "Zip")]
        public string Zip { get; set; }

        [StringLength(200, ErrorMessage = "Email cannot be longer than 200 characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(500, ErrorMessage = "Web URL cannot be longer than 500 characters.")]
        [Display(Name = "Web Url")]
        public string WebURL { get; set; }

        [Display(Name = "is Active?")]
        public bool Active { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created Date")]
        public string DateCreated { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Updated Date")]
        public string LastModified { get; set; }
        
        //SETUP OUR STATES PROPERTIES
        public virtual States States { get; set; }


    }//END CLASS CARRIERS
}