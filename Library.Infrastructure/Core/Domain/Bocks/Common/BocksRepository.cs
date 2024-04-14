using Library.Core.Domain.Bocks.Common;
using Library.Core.Domain.Bocks.Models;
using Microsoft.EntityFrameworkCore;

public class BocksRepository : IBocksRepository
{
    private readonly ApplicationDbContext _context;

    public BocksRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Bock> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Bocks.FindAsync(new object[] { id }, cancellationToken);
    }
    public async Task<IReadOnlyCollection<Bock>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await _context.Bocks
            .Where(bock => ids.Contains(bock.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Bock bock, CancellationToken cancellationToken)
    {
        await _context.Bocks.AddAsync(bock, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Bock> CreateAsync(Bock bock, CancellationToken cancellationToken)
    {
        _context.Bocks.Add(bock);
        await _context.SaveChangesAsync(cancellationToken);
        return bock;
    }

    public async Task UpdateAsync(Bock bock, CancellationToken cancellationToken)
    {
        _context.Bocks.Update(bock);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Delete(IReadOnlyCollection<Bock> bocks)
    {
        _context.Bocks.RemoveRange(bocks);
        _context.SaveChanges();
    }

    public async Task<List<Bock>> GetBocksAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        return await _context.Bocks
            .OrderBy(bock => bock.Title)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}
