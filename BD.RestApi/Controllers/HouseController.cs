using BD.Services.House;
using BD.Services.Models;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IHouseService houseService;
        public HouseController(IHouseService _houseService)
        {
            houseService = _houseService;
        }

        [HttpGet("getHouse")]
        public HouseInfo getHouse(int id)
        {
            try
            {
                return houseService.getHouse(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("",ex);
            }
        }

        [HttpGet("getAllHouses")]
        public IEnumerable<HouseInfo> getAllHouses()
        {
            try
            {
                return houseService.getAllHouses();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }

        [HttpPost("addOrUpdateHouse")]
        public void addOrUpdateHouse(HouseInfo house)
        {
            try
            {
                houseService.addOrUpdateHouse(house);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }

        [HttpDelete("deleteHouse")]
        public void deleteHouse(int id)
        {
            try
            {
                houseService.deleteHouse(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }

        
    }
}
