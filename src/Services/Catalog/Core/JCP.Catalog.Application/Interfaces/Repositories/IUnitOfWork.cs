using System;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Catalog.Application.Interfaces.Repositories
{
    // TODO: Move to common project
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit(CancellationToken cancellationToken);
    }
}
