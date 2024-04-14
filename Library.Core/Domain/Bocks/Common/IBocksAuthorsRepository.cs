using Library.Core.Domain.Bocks.Models;

namespace Library.Core.Domain.Bocks.Common
{
    public interface IBocksAuthorsRepository
    {
        void Add(BockAuthor bockAuthor);

        Task<BockAuthor> FindBockAuthorAsync(Guid bockId, Guid authorId);

        void Delete(BockAuthor bockAuthor);
    }
}
