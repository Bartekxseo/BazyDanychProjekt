﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BD.Domain.Entities;
using BD.Services.Models;
using System;
using System.Linq;
using System.Text;

namespace BD.Services
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {

            CreateMap<Dom, HouseInfo>();
            CreateMap<HouseInfo, Dom>();

            CreateMap<LicznikPradu, MeterInfo>();
            CreateMap<LicznikWody, MeterInfo>();

            CreateMap<MeterInfo, LicznikPradu>();
            CreateMap<MeterInfo,LicznikWody>();
            
        }
    }
}
