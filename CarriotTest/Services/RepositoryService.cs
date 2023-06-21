using CarriotTest.Db;
using CarriotTest.Db.Entities;
using Microsoft.EntityFrameworkCore;
 
using System.Transactions;

namespace CarriotTest.Services
{
    public interface IRepository<T> where T : class
    {
        public void Insert (IList<T> list);
    }

    public interface ITempLogService:IRepository<TempLog>  {}

    public class TempLogRepository : Repository<TempLog>, ITempLogService{}
    

    public interface IWarningService : IRepository<HasWarning>{}

    public class WarningRepository : Repository<HasWarning>, IWarningService{}
    

    public class Repository<T> where T : class  
    {
     
        public     void Insert (IList<T> list)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                 DbContext context = null;
                try
                {
                    context = new CarriotDbContext();
                    context.ChangeTracker.AutoDetectChangesEnabled = false;

                  

                    int count = 0;
                    foreach (var entityToInsert in list)
                    {
                        ++count;
                       
                          context = AddToContext(context, entityToInsert, count, 100, true);
                    }

                       context.SaveChanges();

                }
                finally
                {
                    if (context != null)
                        context.Dispose();
                }
                scope.Complete();
            }
        }
        private   DbContext AddToContext( DbContext context, T entity, int count, int commitCount, bool recreateContext)
   
        {
            context.Set<T>().Add(entity);

            if (count % commitCount == 0)
            {
                context.SaveChanges();
                if (recreateContext)
                {
                    context.Dispose();
                    context = new CarriotDbContext();
                    context.ChangeTracker.AutoDetectChangesEnabled = false;
                }
            }

            return context;
        }

    }
}
