using DataAccessLayer.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Room:Base
    {
        public int RoomNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public float Price { get; set; }
    }
}
