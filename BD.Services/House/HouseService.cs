using AutoMapper;
using AutoMapper.QueryableExtensions;
using BD.DataAccess;
using BD.Domain.Entities;
using BD.Services.DbHelper;
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
        private readonly IDbHelper dbHelper;
        public HouseService(BDDbContext _dbContext,IMapper _mapper,IDbHelper _dbHelper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
            dbHelper = _dbHelper;

        }

        public void addOrUpdateHouse(HouseInfo houseInfo)
        {
            var house = mapper.Map<Dom>(houseInfo);
            dbContext.Set<Dom>().AddOrUpdate(house);
            dbContext.SaveChanges();
        }

        public List<HouseInfo> getAllHouses()
        {
            return dbHelper.Get<Dom>().ProjectTo<HouseInfo>(mapper.ConfigurationProvider).ToList();
        }

        public HouseInfo getHouse(int id)
        {
            return dbHelper.GetWhere<Dom>(x=>x.Id == id).ProjectTo<HouseInfo>(mapper.ConfigurationProvider).SingleOrDefault();
        }

        public void deleteHouse(int id)
        {
            var house = dbContext.Set<Dom>().Where(x => x.Id == id).FirstOrDefault();
            dbContext.Set<Dom>().Remove(house);
            dbContext.SaveChanges();
        }
    }
}
