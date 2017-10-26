using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Nerd_Dinner.Models
{
    public class D_Model
    {
        public NerdDinnerDataContext context = new NerdDinnerDataContext();

       [Key]
        public int Dinner_ID { get; set; }

        [Required(ErrorMessage="Title is required")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string HostedBy { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone Number")]
        public string Contact { get; set; }

       [Required(ErrorMessage = "Need to specify")]

        public string Address { get; set; }

    }
}