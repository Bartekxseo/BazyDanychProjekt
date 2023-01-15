using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace BD.DataAccess
{
    public class BDDbContextFactory : IDbContextFactory<BDDbContext>
    {
        public BDDbContextFactory()
        {
        }

        public BDDbContext Create()
        {
            
           return new BDDbContext(@"Server=localhost\SQLExpress;Database=LicznikDB;Integrated Security=true;");
        }
    }
}
