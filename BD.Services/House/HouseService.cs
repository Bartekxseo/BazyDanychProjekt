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

namespace BD.Services.House
{
    public class HouseService : IHouseService
    {
        private readonly BDDbContext dbContext;
        private readonly IMapper mapper;
        public HouseService(BDDbContext _dbContext,IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;

        }

        public void addOrUpdateHouse(HouseInfo houseInfo)
        {
            var house = mapper.Map<Dom>(houseInfo);
            dbContext.Set<Dom>().AddOrUpdate(house);
            dbContext.SaveChanges();
        }

        public List<HouseInfo> getAllHouses()
        {
            return dbContext.Set<Dom>().ProjectTo<HouseInfo>(mapper.ConfigurationProvider).ToList();
        }

        public HouseInfo getHouse(int id)
        {
            return dbContext.Set<Dom>().Where(x => x.Id == id).ProjectTo<HouseInfo>(mapper.ConfigurationProvider).SingleOrDefault();
        }
    }
}
