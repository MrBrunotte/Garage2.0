using System;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Parking Time")]
        public TimeSpan Period { get; set; }
        public double Cost { get; set; }
    }
}
