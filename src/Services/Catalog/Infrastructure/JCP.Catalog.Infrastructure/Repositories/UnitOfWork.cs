using JCP.Catalog.Application.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Catalog.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogContext _dbContext;
        private bool disposed;

        public UnitOfWork(CatalogContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            var ret = 0;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    ret = await _dbContext.SaveChangesAsync(cancellationToken);
                    await dbContextTransaction.CommitAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }

            }
            return ret;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }


    }
}
