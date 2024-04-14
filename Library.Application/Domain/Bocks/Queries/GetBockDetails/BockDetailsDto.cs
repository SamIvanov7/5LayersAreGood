namespace Library.Application.Domain.Bocks.Dtos;

public record BockDetailsDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public Guid AuthorId { get; init; }
    public string Genre { get; init; }
}
