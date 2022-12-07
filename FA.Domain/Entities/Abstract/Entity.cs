using System;
using System.Collections.Generic;
using System.Text;

namespace FA.Domain.Entities.Abstract
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}
