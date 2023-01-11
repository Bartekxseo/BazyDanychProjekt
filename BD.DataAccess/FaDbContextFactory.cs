using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace BD.DataAccess
{
    public class FADbContextFactory : IDbContextFactory<BDDbContext>
    {
        public FADbContextFactory()
        {
        }

        public BDDbContext Create()
        {
            
           return new BDDbContext(@"Server=localhost\SQLExpress;Database=LicznikDB;Integrated Security=true;");
        }
    }
}
