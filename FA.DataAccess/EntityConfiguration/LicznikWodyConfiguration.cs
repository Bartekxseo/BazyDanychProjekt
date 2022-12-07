using FA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace FA.DataAccess.EntityConfiguration
{
    public class LicznikWodyConfiguration : EntityTypeConfiguration<LicznikWody>
    {
        public LicznikWodyConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Value).IsRequired();
            HasRequired(x => x.Dom).WithMany().HasForeignKey(x => x.DomId);
        }
    }
}
