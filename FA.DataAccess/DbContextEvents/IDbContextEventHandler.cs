using System.Data.Entity;

namespace FA.DataAccess.DbContextEvents
{
    public interface IDbContextEventHandler
    {
        string Code { get; }

        void HandleBeforeSave(DbContext dbContext, DbContextEventHandlerContext dataContext);

        void HandleAfterSave(DbContext dbContext, DbContextEventHandlerContext dataContext);
    }
}
