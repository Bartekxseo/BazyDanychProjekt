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
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BD.Services.Meter
{
    public class MeterService : IMeterService
    {
        private readonly BDDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IDbHelper dbHelper;
        public MeterService(BDDbContext _dbCotext, IMapper _mapper,IDbHelper _dbHelper)
        {
            dbContext = _dbCotext;
            mapper = _mapper;
            dbHelper = _dbHelper;
        }

        public void addOrUpdateMeterValue(MeterInfo value, string type)
        {
            if(type == "Wody")
            {
                var valueDb = mapper.Map<LicznikWody>(value);
                dbContext.Set<LicznikWody>().AddOrUpdate(valueDb);
            }
            else
            {
                var valueDb = mapper.Map<LicznikPradu>(value);
                dbContext.Set<LicznikPradu>().AddOrUpdate(valueDb);
            }
            dbContext.SaveChanges();
        }

        public void deleteMeterValue(int id, string type)
        {
            if (type == "Wody")
            {
                var value = dbContext.Set<LicznikWody>().Where(x => x.Id == id).FirstOrDefault();
                dbContext.Set<LicznikWody>().Remove(value);
            }
            else
            {
                var value = dbContext.Set<LicznikPradu>().Where(x => x.Id == id).FirstOrDefault();
                dbContext.Set<LicznikPradu>().Remove(value);
            }
            dbContext.SaveChanges();
        }

        public MeterInfos getMeterValuesForHouse(int id)
        {
            var electricityInfo = dbHelper.GetWhere<LicznikPradu>(x=>x.DomId == id).ProjectTo<MeterInfo>(mapper.ConfigurationProvider).ToList();
            var waterInfo = dbHelper.GetWhere<LicznikWody>(x=>x.DomId == id).ProjectTo<MeterInfo>(mapper.ConfigurationProvider).ToList();
            return new MeterInfos
            {
                ElectricityMeter = electricityInfo,
                WaterMeter = waterInfo
            };
        }
    }
}
