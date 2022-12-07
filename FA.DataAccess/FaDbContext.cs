using FA.DataAccess.DbContextEvents;
using FA.Domain.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using Unity;

namespace FA.DataAccess
{
    public class FADbContext : DbContext
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static Func<string> LoggerFunction;
        public IDbContextEventDispatcher DbContextEventDispatcher { get; set; }

        public FADbContext(string connString) : base(connString)
        {
            logger.Info(this.Database.Connection.ConnectionString);

            //try
            //{
            //    DbContextEventDispatcher = UnityContainerExtensions.ResolveAll<IDbContextEventDispatcher>();
            //}
            //catch (DSRContainerExceprion ex)
            //{
            //    logger.Info(ex, ex.Message);

            //}
            try
            {
                if (LoggerFunction != null)
                {
                    logger.Info(LoggerFunction());
                }
            }
            catch (Exception ex) { logger.Error(ex); }
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FADbContext, Migrations.Configuration>());
            //Thread thread = Thread.CurrentThread;
            //var msg = String.Format(
            //   String.Format("   Background: {0}\n", thread.IsBackground) +
            //   String.Format("   Thread Pool: {0}\n", thread.IsThreadPoolThread) +
            //   String.Format("   Thread ID: {0}\n", thread.ManagedThreadId));
            //logger.Info(msg);
        }

        //public DbSet<PlcMessage> PlcMessage { get; set; }
        //public DbSet<Machine> Machine { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<TypeNameForeignKeyDiscoveryConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                DbContextEventDispatcher?.OnBeforeSave(this);
                return base.SaveChanges();
            }

            catch (Exception ex)
            {
                throw new Exception("FADbContext.SaveChanges:\n" + ex.Message + "\n" + ex.InnerException?.Message + "\n" + ex.StackTrace, ex);
            }
        }

    }
    public static class DbSetExtensions
    {
        public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            var exists = predicate != null ? dbSet.Count(predicate) != 0 : dbSet.Count() != 0;
            return !exists ? dbSet.Add(entity) : null;
        }
    }
}
