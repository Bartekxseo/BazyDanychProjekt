using BD.Services.Meter;
using BD.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;

namespace BD.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterController : ControllerBase
    {
        private readonly IMeterService meterService;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public MeterController(IMeterService _meterService)
        {
            meterService = _meterService;
        }

        [HttpGet("getMeterValuesForHouse")]
        public MeterInfos getMeterValuesForHouse(int id)
        {
            try
            {
                return meterService.getMeterValuesForHouse(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("",ex);
            }
        }

        [HttpPost("addOrUpdateWaterMeterValue")]
        public void addOrUpdateWaterMeterValue(MeterInfo value)
        {
            try
            {
                meterService.addOrUpdateMeterValue(value, "Wody");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }

        [HttpPost("addOrUpdateElectricityMeterValue")]
        public void addOrUpdateElectricityrMeterValue(MeterInfo value)
        {
            try
            {
                meterService.addOrUpdateMeterValue(value, "Pradu");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }

        [HttpDelete("deleteWaterMeterValue")]
        public void deleteWaterMeterValue(int id)
        {
            try
            {
                meterService.deleteMeterValue(id, "Wody");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }

        [HttpDelete("deleteElectricityMeterValue")]
        public void addOrUpdateElectricityrMeterValue(int id)
        {
            try
            {
                meterService.deleteMeterValue(id, "Pradu");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }
    }
}
