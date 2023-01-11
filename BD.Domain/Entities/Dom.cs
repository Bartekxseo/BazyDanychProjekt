using BD.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Domain.Entities
{
    public class Dom : Entity<int>
    {
        public string Name { get; set; }
    }
}
