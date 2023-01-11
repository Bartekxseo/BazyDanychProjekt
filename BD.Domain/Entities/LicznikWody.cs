using BD.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Domain.Entities
{
    public class LicznikWody : Entity<int>
    {
        public int Value { get; set; }

        public int DomId { get; set; }

        public Dom Dom { get; set; }
    }
}
