using AutoMapper;
using Business_Layer.DTOS;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Mapping
{
    public class BookingProfile:Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>();

            CreateMap<BookingDto, Booking>()
                .ForMember(p => p.Id, opt => opt.Ignore());

        }
    }
}
