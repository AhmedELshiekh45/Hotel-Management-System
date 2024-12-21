using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOS
{
    public class ServiceDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public IEnumerable<ServiceRequestDto>? Requests { get; set; }
    }
}
