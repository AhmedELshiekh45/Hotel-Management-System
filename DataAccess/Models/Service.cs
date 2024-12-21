using DataAccessLayer.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Service:Base
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }

        public virtual ICollection<ServiceRequest>? ServiceRequests { get; set; }
    }
}
