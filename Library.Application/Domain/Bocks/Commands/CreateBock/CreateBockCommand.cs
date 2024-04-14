using MediatR;

namespace Library.Application.Domain.Bocks.Commands.CreateBock
{
    public class CreateBockCommand : IRequest<Guid>
    {
        public string Title { get; }
        public Guid AuthorId { get; }
        public string Genre { get; }

        public CreateBockCommand(string title, Guid authorId, string genre)
        {
            Title = title;
            AuthorId = authorId;
            Genre = genre;
        }
    }
}
