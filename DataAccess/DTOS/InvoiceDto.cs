using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOS
{
    public class InvoiceDto
    {
        public string Id { get; set; } 
        public string BookingId { get; set; }

        public float TotalAmount { get; set; }

    }
}
