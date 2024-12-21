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
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomDto, Room>()
                .ForMember(p => p.Id, opt => opt.Ignore());

            CreateMap<Room, RoomDto>();



        }
    }
}
