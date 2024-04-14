using Library.Core.Common;
using Library.Core.Domain.Bocks.Data;
using Library.Core.Domain.Bocks.Validators;

namespace Library.Core.Domain.Bocks.Models;

public class Bock : Entity, IAggregateRoot
{
    private Bock()
    {
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public Guid AuthorId { get; private set; }
    public string Genre { get; private set; }
    public string Description { get; private set; }
    public List<BockAuthor> BocksAuthors { get; private set; } = new List<BockAuthor>();

    public static Bock Create(CreateBockData data)
    {
        Validate(new CreateBockValidator(), data);

        return new Bock
        {
            Id = Guid.NewGuid(),
            Title = data.Title,
            AuthorId = data.AuthorId,
            Genre = data.Genre,
            Description = data.Description
        };
    }

    public void Update(UpdateBockData data)
    {
        Validate(new UpdateBockValidator(), data);

        Title = data.Title;
        AuthorId = data.AuthorId;
        Genre = data.Genre;
        Description = data.Description;
    }
}
