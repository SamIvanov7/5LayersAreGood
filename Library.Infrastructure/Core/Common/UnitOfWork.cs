using Library.Core.Common;
using Library.Infrastructure.Processing;
using Library.Persistence;

namespace Library.Infrastructure.Core.Common;

internal class UnitOfWork(
    LibrariesDbContext librariesDbContest,
    IEnumerationIgnorer enumerationIgnorer)
    : IUnitOfWork
{
    private readonly LibrariesDbContext _librariesDbContest = librariesDbContest ?? throw new ArgumentNullException(nameof(librariesDbContest));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        enumerationIgnorer.IgnoreEnumerations();
        return await _librariesDbContest.SaveChangesAsync(cancellationToken);
    }
}
