using Library.Core.Domain.Bocks.Models;
using Library.Core.Domain.Bocks.Common;
using Library.Core.Exceptions;
using Library.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Bocks.Common
{
    public class BocksAuthorsRepository : IBocksAuthorsRepository
    {
        private readonly LibrariesDbContext _librariesDbContext;

        public BocksAuthorsRepository(LibrariesDbContext librariesDbContext)
        {
            _librariesDbContext = librariesDbContext;
        }

        public void Add(BockAuthor BockAuthor)
        {
            _librariesDbContext.BocksAuthors.Add(BockAuthor);
        }

        public async Task<BockAuthor> FindBockAuthorAsync(Guid BockId, Guid authorId)
        {
            return await _librariesDbContext.BocksAuthors
                .FirstOrDefaultAsync(ba => ba.BockId == BockId && ba.AuthorId == authorId)
                ?? throw new NotFoundException($"BockAuthor with Bock ID {BockId} and Author ID {authorId} was not found.");
        }

        public void Delete(BockAuthor BockAuthor)
        {
            _librariesDbContext.BocksAuthors.Remove(BockAuthor);
        }
    }
}