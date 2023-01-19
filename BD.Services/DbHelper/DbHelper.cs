using BD.DataAccess;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Data.SqlClient;
using AutoMapper;
using BD.Domain.Entities;
using BD.Services.Models;

namespace BD.Services.DbHelper
{

    public class DbHelper : IDbHelper
    {
        private readonly BDDbContext dbContext;
        private readonly BDRead1DbContext dbRead1Context;
        private readonly BDRead2DbContext dbRead2Context;
        private int iterator = 0;

        public DbHelper(BDRead2DbContext dbRead2Context, BDRead1DbContext dbRead1Context, BDDbContext dbContext)
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

                throw new Exception("", ex);
            }
        }

        public DbSet<T> Get<T>() where T : class
        {
            var dbList = new List<DbContext>() { dbRead1Context, dbRead2Context };
            if(iterator%2==1)
            {
                dbList.Reverse();
            }
            foreach (var context in dbList)
            {
                try
                {
                    context.Set<Dom>().FirstOrDefault();
                    iterator++;
                    return context.Set<T>();
                }
                catch (Exception) {}
            }
            try
            {
                dbContext.Set<Dom>().FirstOrDefault();
                return dbContext.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("",ex);
            }
        }
    }
}
