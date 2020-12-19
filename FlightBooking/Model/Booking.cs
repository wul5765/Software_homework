using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Model
{
    public class Booking
    {
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public CabinType CabinType { get; set; }
        public LuggageType LuggageType { get; set; }
        public List<PremiumService> PremiumServices { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double FinalPrice { get; set; }
        public DateTime BookingDate { get; set; }

    }

    public enum LuggageType
    {
        Checked,
        Carry_on 
    }

    public enum CabinType
    {
        Economy,
        Business,
        First
    }
}
