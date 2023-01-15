using AutoMapper;
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

            CreateMap<LicznikPradu, MeterInfo>()
                .ForMember(s => s.HouseId, d => d.MapFrom(x => x.DomId));
            CreateMap<LicznikWody, MeterInfo>()
                .ForMember(s => s.HouseId, d => d.MapFrom(x => x.DomId));

            CreateMap<MeterInfo, LicznikPradu>()
                .ForMember(s => s.DomId, d => d.MapFrom(x => x.HouseId));
            CreateMap<MeterInfo,LicznikWody>()
                .ForMember(s => s.DomId, d => d.MapFrom(x => x.HouseId));

        }
    }
}
