using System;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
    public class ParkedVehicle
    {
        // Public so that it is accessible 
        // Add Data Annotations for each property
        public int ID { get; set; }

        [Required, StringLength(30)]
        public VehicleType VehicleType { get; set; }

        [Required, StringLength(8)]
        public string RegNum { get; set; }

        [Required]
        public string Color { get; set; }

        [Required, StringLength(15)]
        public string Make { get; set; }

        [Required, StringLength(15)]
        public string Model { get; set; }

        [Required, Display(Name = "Number of Wheels")]
        public int NumOfWheels { get; set; }

        [DataType(DataType.Duration), Display(Name = "Duration of parking")]
        public DateTime ArrivalTime { get; set; }

        [Timestamp]
        public byte[] CheckInTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CheckOutTime { get; set; }

        public bool CheckedIn { get; set; }

    }
}