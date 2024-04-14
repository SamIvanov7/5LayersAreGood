namespace Library.Application.Domain.Bocks.Queries.GetBocks;

public record BockDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public Guid AuthorId { get; init; }
    public string Genre { get; init; }
}
