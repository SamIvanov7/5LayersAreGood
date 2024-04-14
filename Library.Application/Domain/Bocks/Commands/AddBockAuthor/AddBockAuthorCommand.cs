using MediatR;
using System;

namespace Library.Application.Domain.Bocks.Commands.AddBockAuthor
{
    public class AddBockAuthorCommand : IRequest
    {
        public Guid BockId { get; }
        public Guid AuthorId { get; }

        public AddBockAuthorCommand(Guid bockId, Guid authorId)
        {
            BockId = bockId;
            AuthorId = authorId;
        }
    }
}
