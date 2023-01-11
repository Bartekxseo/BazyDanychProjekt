using AutoMapper;
using AutoMapper.QueryableExtensions;
using BD.DataAccess;
using BD.Domain.Entities;
using BD.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace BD.Services.Type
{
    public class TypeService : ITypeService
    {
        private readonly BDDbContext BDDbContext;
        private readonly Mapper mapper;
        public TypeService(BDDbContext _faDbContext, Mapper _mapper)
        {
            BDDbContext = _faDbContext;
            mapper = _mapper;
        }

        public void addDislikedMovieType(int userId, int typeId)
        {
            var type = BDDbContext.Set<MovieTypesEnum>().Where(x => x.Id == typeId).FirstOrDefault();
            var user = BDDbContext.Set<Domain.Entities.User>().Where(x => x.Id == userId).FirstOrDefault();
            user.HatedMovieTypes.Add(type);
            BDDbContext.Set<Domain.Entities.User>().AddOrUpdate(user);
            BDDbContext.SaveChanges();
        }

        public void addLikedMovieType(int userId, int typeId)
        {
            var type = BDDbContext.Set<MovieTypesEnum>().Where(x => x.Id == typeId).FirstOrDefault();
            var user = BDDbContext.Set<Domain.Entities.User>().Where(x => x.Id == userId).FirstOrDefault();
            user.LikedMovieTypes.Add(type);
            BDDbContext.Set<Domain.Entities.User>().AddOrUpdate(user);
            BDDbContext.SaveChanges();
        }

        public List<TypeInfo> getAllMovieTypes()
        {
            return BDDbContext.Set<MovieTypesEnum>().AsNoTracking().ProjectTo<TypeInfo>(mapper.ConfigurationProvider).ToList();
        }

        public List<TypeInfo> getDislikedMovieTypes(int userId)
        {
            return BDDbContext.Set<Domain.Entities.User>().AsNoTracking().Where(x=>x.Id == userId).Select(x=>x.HatedMovieTypes).ProjectTo<TypeInfo>(mapper.ConfigurationProvider).ToList();
        }

        public List<TypeInfo> getLikedMovieTypes(int userId)
        {
            return BDDbContext.Set<Domain.Entities.User>().AsNoTracking().Where(x => x.Id == userId).Select(x => x.LikedMovieTypes).ProjectTo<TypeInfo>(mapper.ConfigurationProvider).ToList();
        }

        public void removeDislikedMovieType(int userId, int typeId)
        {
            var type = BDDbContext.Set<MovieTypesEnum>().Where(x => x.Id == typeId).FirstOrDefault();
            var user = BDDbContext.Set<Domain.Entities.User>().Where(x => x.Id == userId).FirstOrDefault();
            user.HatedMovieTypes.Remove(type);
            BDDbContext.Set<Domain.Entities.User>().AddOrUpdate(user);
            BDDbContext.SaveChanges();
        }

        public void removeLikedMovieType(int userId, int typeId)
        {
            var type = BDDbContext.Set<MovieTypesEnum>().Where(x => x.Id == typeId).FirstOrDefault();
            var user = BDDbContext.Set<Domain.Entities.User>().Where(x => x.Id == userId).FirstOrDefault();
            user.LikedMovieTypes.Remove(type);
            BDDbContext.Set<Domain.Entities.User>().AddOrUpdate(user);
            BDDbContext.SaveChanges();
        }
    }
}
