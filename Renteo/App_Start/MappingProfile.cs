using AutoMapper;
using Renteo.Dtos;
using Renteo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Renteo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember( c => c.Id, opt => opt.Ignore());
            CreateMap<CustomerDto, Customer>();
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<VehicleDto, Vehicle>();

        }
    }
}