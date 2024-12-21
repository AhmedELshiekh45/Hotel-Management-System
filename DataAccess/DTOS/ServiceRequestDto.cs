using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOS
{
    public class ServiceRequestDto
    {
        public string BookingId { get; set; }
        public string ServiceId { get; set; }
        public DateTime RequestDate { get; set; }
        public string? Satutes { get; set; }
    }
}
