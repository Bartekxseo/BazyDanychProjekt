using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Domain.Entities.Abstract
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}
