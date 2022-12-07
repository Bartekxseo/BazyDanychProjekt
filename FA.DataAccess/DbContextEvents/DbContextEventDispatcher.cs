using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace FA.DataAccess.DbContextEvents
{
    public interface IDbContextEventDispatcher
    {
        IDbContextEventDispatcher RegisterStep(Func<IDbContextEventHandler> e);

        DbContextEventHandlerContext OnBeforeSave(DbContext dbContext);

        void OnAfterSave(DbContext dbContext, DbContextEventHandlerContext dataContext);
    }

    public class DbContextEventDispatcher : IDbContextEventDispatcher
    {
        readonly IList<Func<IDbContextEventHandler>> steps = new List<Func<IDbContextEventHandler>>();

        public IDbContextEventDispatcher RegisterStep(Func<IDbContextEventHandler> step)
        {
            steps.Add(step);
            return this;
        }

        public DbContextEventHandlerContext OnBeforeSave(DbContext dbContext)
        {
            var dataContext = new DbContextEventHandlerContext();

            foreach (var s in steps)
            {
                s().HandleBeforeSave(dbContext, dataContext);
            }

            return dataContext;
        }

        public void OnAfterSave(DbContext dbContext, DbContextEventHandlerContext dataContext)
        {
            foreach (var s in steps)
            {
                s().HandleAfterSave(dbContext, dataContext);
            }
        }
    }
}
