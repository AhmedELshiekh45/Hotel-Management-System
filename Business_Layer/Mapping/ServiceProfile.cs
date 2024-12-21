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
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceDto>()
                .ForMember(dest => dest.Requests, opt => opt.MapFrom(src => src.ServiceRequests));

            CreateMap<ServiceDto, Service>()
            .ForMember(dest => dest.ServiceRequests, opt => opt.MapFrom(src => src.Requests))
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ServiceRequest, ServiceRequestDto>()
                .ReverseMap();


            CreateMap<Invoice, InvoiceDto>()
                .ReverseMap();
        }
    }
}
