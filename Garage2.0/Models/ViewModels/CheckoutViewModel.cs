using System;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Registration number")]
        public string RegNum { get; set; }

        [Display(Name = "Arrival")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Prel. Checkout")]
        public DateTime CheckOutTime { get; set; }

        [Display(Name = "Parking Time")]
        [DisplayFormat(DataFormatString = "{0:%d}d {0:%h}h {0:%m}m")]
        public TimeSpan Period { get; set; }

        [Display(Name = "Cost per minute")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double CostPerMinute { get; set; }

        [Display(Name = "Preliminary cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Cost { get; set; }
    }
}
