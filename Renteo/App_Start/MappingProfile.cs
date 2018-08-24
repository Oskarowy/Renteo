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
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

        }
    }
}