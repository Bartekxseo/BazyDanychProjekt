using FA.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.Domain.Entities
{
    public class LicznikPradu : Entity<int>
    {
        public int Value { get; set; }

        public int DomId { get; set; }

        public Dom Dom { get; set; }
    }
}
