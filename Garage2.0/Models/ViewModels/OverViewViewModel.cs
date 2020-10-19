using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.ViewModels
{
    public class OverViewViewModel
    {
       // public IEnumerable<ParkedVehicle> VehicleOverViewList { get; set; }

        [Display(Name = "Type of Vehicle")]
        public VehicleType? VehicleType { get; set; }

        [Display(Name = "Registration number")]
        public string RegNum { get; set; }

        [Display(Name = "Arrived")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Parked Time")]
        [DisplayFormat(DataFormatString = "{0:%d}d {0:%h}h {0:%m}m")]
        public TimeSpan Period { get; set; }

    }
}
