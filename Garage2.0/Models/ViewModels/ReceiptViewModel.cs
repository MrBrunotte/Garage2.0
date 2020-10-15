using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2._0.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Registration number")]
        public string RegNum { get; set; }
        [Display(Name = "Time of Arrival")]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "Time of Checkout")]
        public DateTime CheckOutTime { get; set; }
       
        public TimeSpan Period { get; set; }
        public double Cost { get; set; }
    }
}
