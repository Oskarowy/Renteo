﻿using AutoMapper;
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
            // Domain to Dto
            CreateMap<Customer, CustomerDto>();
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<VehicleType, VehicleTypeDto>();
            CreateMap<Rental, RentalDto>();
                

            // Dto to Domain
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<RentalDto, Rental>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}