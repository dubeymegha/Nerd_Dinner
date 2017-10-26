using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nerd_Dinner.Models
{
    public class DinnerModel
    {
        [Display (Name="Dinner Name")]
        public string Title { get; set; }

        //Date and Time validation

        [Required(ErrorMessage = "Start date and time cannot be empty")]
        [Display(Name = "Dinner Date")]
        [DataType(DataType.DateTime)]

        public string EventDate { get; set; }



        [Display(Name = "Details")]
        public string Description { get; set; }

        [Display(Name = "Hosted By")]
        public string HostedBy { get; set; }

        //Phone number Validation

        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }

        
        public string Address { get; set; }

    }
}