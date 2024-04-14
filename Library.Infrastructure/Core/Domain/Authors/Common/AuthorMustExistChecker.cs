using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Authors.Common;
using Library.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Infrastructure.Core.Domain.Authors.Common
{
    public class AuthorMustExistChecker : IAuthorMustExistChecker
    {
        private readonly LibrariesDbContext _librariesDbContext;

        public AuthorMustExistChecker(LibrariesDbContext librariesDbContext)
        {
            _librariesDbContext = librariesDbContext;
        }

        public async Task<bool> ExistsAsync(Guid authorId, CancellationToken cancellationToken)
        {
            return await _librariesDbContext.Authors.AnyAsync(a => a.Id == authorId, cancellationToken);
        }
    }
}
