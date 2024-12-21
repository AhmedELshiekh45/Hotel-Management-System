using DataAccessLayer.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class MaintenanceRequest:Base
    {
        public string RoomId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public virtual Room? Room { get; set; }
    }
}
