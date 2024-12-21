using DataAccess.DTOS;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.DTOS
{
    public class BookingDto
    {
        public string Id { get; set; }
        public string? GustId { get; set; }

        public string? RoomId { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string Stautes { get; set; }

        public virtual UserDto? Gust { get; set; }
        public virtual RoomDto? Room { get; set; }


    }
}
