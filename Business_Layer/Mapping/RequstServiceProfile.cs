using AutoMapper;
using DataAccess.DTOS;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Mapping
{
    public class RequstServiceProfile : Profile
    {
        public RequstServiceProfile()
        {
            CreateMap<ServiceRequestDto, ServiceRequest>()
                .ReverseMap();
        }
    }
}
