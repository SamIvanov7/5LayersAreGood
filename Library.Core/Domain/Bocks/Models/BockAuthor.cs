using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Bocks.Common;
using System;
using System.Threading.Tasks;
using Library.Core.Domain.Bocks.Data;

namespace Library.Core.Domain.Bocks.Models
{
    public class BockAuthor
    {
        public Guid BockId { get; private set; }
        public Bock Bock { get; private set; }
        public Guid AuthorId { get; private set; }
        public Author Author { get; private set; }

        private BockAuthor(Guid bockId, Guid authorId)
        {
            BockId = bockId;
            AuthorId = authorId;
        }

        public static async Task<BockAuthor> Create(
            IAuthorMustExistChecker authorMustExistChecker,
            IBockMustExistChecker bockMustExistChecker,
            CreateBockAuthorData data)
        {
            if (await bockMustExistChecker.ExistsAsync(data.BockId) &&
                await authorMustExistChecker.ExistsAsync(data.AuthorId))
            {
                return new BockAuthor(data.BockId, data.AuthorId);
            }

            throw new InvalidOperationException("Bock or Author does not exist.");
        }
    }
}