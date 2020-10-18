using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class TableViewModel
    {

        [Required]
        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Total Seats")]
        public int seats { get; set; }

        [Required]
        [Display(Name = "From")]
        public TimeSpan Stime { get; set; }

        [Required]
        [Display(Name = "To")]
        public TimeSpan ETime { get; set; }

        [Required]
        [Display(Name = "Booking Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Choose Table")]
        public int tableDropdown { get; set; }
    }
}

