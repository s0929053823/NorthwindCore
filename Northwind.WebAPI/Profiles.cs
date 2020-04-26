using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.DbModels.Model;
using Northwind.WebAPI.Commnads;

namespace Northwind.WebAPI
{

    //When the application starts, every classes that inherit from a Profile class will be registered by
    //AutoMapper and the mapping strategy will be enabled.
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderCommand, Orders>();
            CreateMap<UpdateOrderCommand, Orders>();
        }
    }
}
