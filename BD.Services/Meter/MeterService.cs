using AutoMapper;
using AutoMapper.QueryableExtensions;
using BD.DataAccess;
using BD.Domain.Entities;
using BD.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace BD.Services.Meter
{
    public class MeterService : IMeterService
    {
        private readonly BDDbContext dbContext;
        private readonly IMapper mapper;
        public MeterService(BDDbContext _dbCotext, IMapper _mapper)
        {
            dbContext = _dbCotext;
            mapper = _mapper;
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

        public MeterInfos getMeterValuesForHouse(int id)
        {
            var electricityInfo = dbContext.Set<LicznikPradu>().Where(x => x.DomId == id).ProjectTo<MeterInfo>(mapper.ConfigurationProvider).ToList();
            var waterInfo = dbContext.Set<LicznikWody>().Where(x => x.DomId == id).ProjectTo<MeterInfo>(mapper.ConfigurationProvider).ToList();
            return new MeterInfos
            {
                ElectricityMeter = electricityInfo,
                WaterMeter = waterInfo
            };
        }
    }
}
