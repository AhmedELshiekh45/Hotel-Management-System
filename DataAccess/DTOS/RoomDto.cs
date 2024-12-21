using DataAccessLayer.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.DTOS
{
    public class RoomDto
    {
        public string? Id { get; set; }
        public int RoomNumber { get; set; }
        public string? Type { get; set; }
        public string? Status {  get; set; }

        public float Price { get; set; }

    }
}
