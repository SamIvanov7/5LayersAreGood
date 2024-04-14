using Library.Core.Domain.Bocks.Models;

namespace Library.Core.Domain.Bocks.Common;

public interface IBocksRepository
{
    public Task<Bock> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<Bock>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken);

    public Task AddAsync(Bock bock, CancellationToken cancellationToken);

    public Task<Bock> CreateAsync(Bock bock, CancellationToken cancellationToken);

    public Task UpdateAsync(Bock bock, CancellationToken cancellationToken);

    public void Delete(IReadOnlyCollection<Bock> bocks);

    public Task<List<Bock>> GetBocksAsync(int page, int pageSize, CancellationToken cancellationToken);

}
