namespace Library.Core.Domain.Bocks.Data
{
    public class CreateBockAuthorData
    {
        public Guid BockId { get; }
        public Guid AuthorId { get; }

        public CreateBockAuthorData(Guid bockId, Guid authorId)
        {
            BockId = bockId;
            AuthorId = authorId;
        }
    }
}
