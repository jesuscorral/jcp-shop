using System;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Catalog.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit(CancellationToken cancellationToken);
    }
}
