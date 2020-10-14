using System;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
    public class ParkedVehicle
    {
        // Public so that it is accessible 
        // Add Data Annotations for each property
        public int ID { get; set; }

        [Required, StringLength(30), Display(Name = "Type of Vehicle")]
        public VehicleType VehicleType { get; set; }

        [Required, StringLength(8), Display(Name ="Registration number")]
        public string RegNum { get; set; }

        [Required, Display(Name = "Vehicle Color")]
        public string Color { get; set; }

        [Required, StringLength(15), Display(Name = "Make of Vehicle")]
        public string Make { get; set; }

        [Required, StringLength(15), Display(Name = "Model of Vehicle")]
        public string Model { get; set; }

        [Required, Range(1,20), Display(Name = "Number of Wheels")]
        public int NumOfWheels { get; set; }

        [DataType(DataType.Duration), Display(Name = "Time of Arrival")]
        public DateTime ArrivalTime { get; set; }

        [Timestamp]
        public DateTime CheckInTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Checkout Time")]
        public DateTime CheckOutTime { get; set; }

        public bool CheckedIn { get; set; }

    }
}