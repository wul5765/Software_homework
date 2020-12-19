using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Model
{
    public class Flight
    {
        public string FlightName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime FlightDate { get; set; }  
        public int EconomyAvailable { get; set; } 
        public int BusinessAvailable { get; set; } 
        public int FirstAvailable { get; set; } 
        public double BasePrice { get; set; }
    }

}
