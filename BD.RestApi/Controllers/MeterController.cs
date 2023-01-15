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
        [HttpGet]
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

        [HttpPost]
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

        [HttpPost]
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
    }
}
