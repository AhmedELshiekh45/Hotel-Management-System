using DataAccessLayer.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Invoice:Base
    {
        [ForeignKey("Booking")]
        public string BookingId { get; set; }

        public float TotalAmount { get; set; }

        public virtual Booking? Booking { get; set; }
    }
}
