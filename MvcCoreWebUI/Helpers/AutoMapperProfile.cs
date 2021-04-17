using AutoMapper;
using Entities.Concrete;
using MvcCoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.Helpers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderContactCartViewModel>().ReverseMap();
        }
    }
}
