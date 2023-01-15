using BD.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Services.Meter
{
    public interface IMeterService
    {
        public MeterInfos getMeterValuesForHouse(int id);
        public void addOrUpdateMeterValue(MeterInfo value, string type);
    }
}
