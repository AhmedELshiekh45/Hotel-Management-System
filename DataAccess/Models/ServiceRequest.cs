using DataAccessLayer.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ServiceRequest:Base
    {
        public string BookingId { get; set; }
        public string ServiceId { get; set; }
        public DateTime RequestDate { get; set; }= DateTime.Now;
        public string Satutes { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Service? Service { get; set; }
    }
}
