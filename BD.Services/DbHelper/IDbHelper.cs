using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BD.Services.DbHelper
{
    public interface IDbHelper
    {
        public IQueryable<T> GetWhere<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        public DbSet<T> Get<T>()where T : class;
    }
}
