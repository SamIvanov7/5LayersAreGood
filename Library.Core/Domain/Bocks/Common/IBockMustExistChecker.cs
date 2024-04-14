using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Core.Domain.Bocks.Common
{
    public interface IBockMustExistChecker
    {
        Task<bool> ExistsAsync(Guid bockId, CancellationToken cancellationToken = default);
    }
}
