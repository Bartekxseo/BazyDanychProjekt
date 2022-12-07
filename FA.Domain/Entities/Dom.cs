using FA.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.Domain.Entities
{
    public class Dom : Entity<int>
    {
        public string Name { get; set; }
    }
}
