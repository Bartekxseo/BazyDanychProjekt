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
            CreateMap<Domain.Entities.User, UserInfo>();
            CreateMap<MovieTypesEnum, TypeInfo>()
                .ForMember(d => d.Name, s => s.MapFrom(x => x.Value));
            CreateMap<Movie, MovieInfo>()
                .ForMember(d => d.Title, s => s.MapFrom(x => x.Name))
                .ForMember(d => d.Type, s => s.MapFrom(x => x.MovieTypes));
        }
    }
}
