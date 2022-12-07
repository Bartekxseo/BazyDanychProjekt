using System;
using System.Collections.Generic;
using System.Text;

namespace FA.Domain.Entities.Abstract
{
    public abstract class EnumEntity : Entity<int>
    {
        public string Value { get; set; }
    }
}
