using DataAccessLayer.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Payment:Base
    {
        [ForeignKey("Invoice")]
        public string InvoiceId { get; set; }
        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
        public virtual Invoice? Invoice { get; set; }
    }
}
