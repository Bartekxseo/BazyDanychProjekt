using BD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace BD.DataAccess.EntityConfiguration
{
    public class DomConfiguration : EntityTypeConfiguration<Dom>
    {
        public DomConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired();
        }
    }
}
