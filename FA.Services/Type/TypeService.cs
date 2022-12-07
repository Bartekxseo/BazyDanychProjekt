using AutoMapper;
using AutoMapper.QueryableExtensions;
using FA.DataAccess;
using FA.Domain.Entities;
using FA.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace FA.Services.Type
{
    public class TypeService : ITypeService
    {
        private readonly FADbContext faDbContext;
        private readonly Mapper mapper;
        public TypeService(FADbContext _faDbContext, Mapper _mapper)
        {
            faDbContext = _faDbContext;
            mapper = _mapper;
        }

        public void addDislikedMovieType(int userId, int typeId)
        {
            var type = faDbContext.Set<MovieTypesEnum>().Where(x => x.Id == typeId).FirstOrDefault();
            var user = faDbContext.Set<Domain.Entities.User>().Where(x => x.Id == userId).FirstOrDefault();
            user.HatedMovieTypes.Add(type);
            faDbContext.Set<Domain.Entities.User>().AddOrUpdate(user);
            faDbContext.SaveChanges();
        }

        public void addLikedMovieType(int userId, int typeId)
        {
            var type = faDbContext.Set<MovieTypesEnum>().Where(x => x.Id == typeId).FirstOrDefault();
            var user = faDbContext.Set<Domain.Entities.User>().Where(x => x.Id == userId).FirstOrDefault();
            user.LikedMovieTypes.Add(type);
            faDbContext.Set<Domain.Entities.User>().AddOrUpdate(user);
            faDbContext.SaveChanges();
        }

        public List<TypeInfo> getAllMovieTypes()
        {
            return faDbContext.Set<MovieTypesEnum>().AsNoTracking().ProjectTo<TypeInfo>(mapper.ConfigurationProvider).ToList();
        }

        public List<TypeInfo> getDislikedMovieTypes(int userId)
        {
            return faDbContext.Set<Domain.Entities.User>().AsNoTracking().Where(x=>x.Id == userId).Select(x=>x.HatedMovieTypes).ProjectTo<TypeInfo>(mapper.ConfigurationProvider).ToList();
        }

        public List<TypeInfo> getLikedMovieTypes(int userId)
        {
            return faDbContext.Set<Domain.Entities.User>().AsNoTracking().Where(x => x.Id == userId).Select(x => x.LikedMovieTypes).ProjectTo<TypeInfo>(mapper.ConfigurationProvider).ToList();
        }

        public void removeDislikedMovieType(int userId, int typeId)
        {
            var type = faDbContext.Set<MovieTypesEnum>().Where(x => x.Id == typeId).FirstOrDefault();
            var user = faDbContext.Set<Domain.Entities.User>().Where(x => x.Id == userId).FirstOrDefault();
            user.HatedMovieTypes.Remove(type);
            faDbContext.Set<Domain.Entities.User>().AddOrUpdate(user);
            faDbContext.SaveChanges();
        }

        public void removeLikedMovieType(int userId, int typeId)
        {
            var type = faDbContext.Set<MovieTypesEnum>().Where(x => x.Id == typeId).FirstOrDefault();
            var user = faDbContext.Set<Domain.Entities.User>().Where(x => x.Id == userId).FirstOrDefault();
            user.LikedMovieTypes.Remove(type);
            faDbContext.Set<Domain.Entities.User>().AddOrUpdate(user);
            faDbContext.SaveChanges();
        }
    }
}
