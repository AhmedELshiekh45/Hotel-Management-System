using DataAccessLayer.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Booking : Base
    {
        [ForeignKey("Gust")]
        public string GustId { get; set; }

        [ForeignKey("Room")]
        public string RoomId { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string Stautes { get; set; }

        public virtual User? Gust { get; set; }
        public virtual Room? Room { get; set; }
        public virtual IEnumerable<ServiceRequest>? ServiceRequests { get; set; }
    }
}
