using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace FA.DataAccess.DbContextEvents.Handlers
{
    public class EntityHistoryDbContextEventHandler : IDbContextEventHandler
    {

        public EntityHistoryDbContextEventHandler(
            )
        {
        }

        public string Code { get; } = nameof(EntityHistoryDbContextEventHandler);

        public void HandleAfterSave(DbContext dbContext, DbContextEventHandlerContext dataContext)
        {
            
        }

        public void HandleBeforeSave(DbContext dbContext, DbContextEventHandlerContext dataContext)
        {

        }


        private IEnumerable<TEntity> GetChangedEntity<TEntity>(DbContext dbContext)
        {
            return dbContext.ChangeTracker.Entries()
                .Where(x => typeof(TEntity).IsAssignableFrom(x.Entity.GetType()))
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .Cast<TEntity>();
        }

        private IEnumerable<TEntity> GetAddedEntity<TEntity>(DbContext dbContext)
        {
            return dbContext.ChangeTracker.Entries()
                .Where(x => typeof(TEntity).IsAssignableFrom(x.Entity.GetType()))
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity)
                .Cast<TEntity>();
        }

        private IEnumerable<TEntity> GetDeletedEntity<TEntity>(DbContext dbContext)
        {
            return dbContext.ChangeTracker.Entries()
                .Where(x => typeof(TEntity).IsAssignableFrom(x.Entity.GetType()))
                .Where(x => x.State == EntityState.Deleted)
                .Select(x => x.Entity)
                .Cast<TEntity>();
        }
    }
}
