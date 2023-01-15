using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Services.Models
{
    public class MeterInfos
    {
        public IEnumerable<MeterInfo> WaterMeter { get; set; }
        public IEnumerable<MeterInfo> ElectricityMeter { get; set; }
    }
}
