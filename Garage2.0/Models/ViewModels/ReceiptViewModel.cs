using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2._0.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public string RegNum { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public TimeSpan Period {
            get
            {
                return CheckOutTime - ArrivalTime;
            } 
        }
        public float Cost { get; set; }
    }
}
