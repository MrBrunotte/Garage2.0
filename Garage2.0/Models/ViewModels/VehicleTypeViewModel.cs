using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2._0.Models
{
    // Added by Stefan for the search function
    public class VehicleTypeViewModel
    {
        public IEnumerable<ParkedVehicle> VehicleList { get; set; }
        public IEnumerable<SelectListItem> VehicleTypes { get; set; }
        public VehicleType? VehicleType { get; set; }
        public string SearchString { get; set; }
    }
}
