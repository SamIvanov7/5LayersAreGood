using MediatR;
using System;

namespace Library.Application.Domain.Bocks.Commands.UpdateBock
{
    public class UpdateBockCommand : IRequest
    {
        public Guid Id { get; }
        public string Title { get; }
        public Guid AuthorId { get; }
        public string Genre { get; }

        public UpdateBockCommand(Guid id, string title, Guid authorId, string genre)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            Genre = genre;
        }
    }
}
