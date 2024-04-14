namespace Library.Core.Domain.Bocks.Data;

public class UpdateBockData
{
    public string Title { get; set; }
    public Guid AuthorId { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }

    public UpdateBockData(string title, Guid authorId, string genre, string description)
    {
        Title = title;
        AuthorId = authorId;
        Genre = genre;
        Description = description;
    }
}
