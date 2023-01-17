using BD.DataAccess;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Linq;

namespace BD.Services.DbHelper
{
    
    public class DbHelper : IDbHelper
    {
        private readonly BDDbContext dbContext;
        private readonly BDRead1DbContext dbRead1Context;
        private readonly BDRead2DbContext dbRead2Context;
        private int iterator = 0;
        public DbHelper(BDRead2DbContext dbRead2Context,BDRead1DbContext dbRead1Context,BDDbContext dbContext)
        {
            this.dbRead2Context = dbRead2Context;
            this.dbRead1Context = dbRead1Context;
            this.dbContext = dbContext;
        }

        public IQueryable<T> GetWhere<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            try
            {
                return Get<T>().Where(predicate);
            }
            catch (Exception ex)
            {

                throw new Exception("",ex);
            }
        }

        public DbSet<T> Get<T>() where T : class
        {
            if (iterator % 3 == 0)
            {
                try
                {
                    iterator++;
                    return dbRead1Context.Set<T>();
                }
                catch (Exception)
                {
                    return Get<T>();
                }
            }
            else if(iterator % 3 == 1)
            {
                try
                {
                    iterator++;
                    return dbRead2Context.Set<T>();
                }
                catch (Exception)
                {

                    return Get<T>();
                }
            }
            else
            {
                try
                {
                    iterator++;
                    return dbContext.Set<T>();
                }
                catch (Exception)
                {

                    return Get<T>();
                }
            }
        }
    }
}
