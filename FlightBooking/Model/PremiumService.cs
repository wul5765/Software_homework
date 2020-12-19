using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Model
{
    public class PremiumService
    {
        public string ServiceName { get; set; }
        public double Price { get; set; }  
        public double VipDiscount { get; set; }
    }
}
