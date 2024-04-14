using MediatR;
using System;

namespace Library.Application.Domain.Bocks.Commands.RemoveBockAuthor
{
   
    public class RemoveBockAuthorCommand : IRequest
    {
        public Guid BockId { get; }
        public Guid AuthorId { get; }

        public RemoveBockAuthorCommand(Guid bockId, Guid authorId)
        {
            BockId = bockId;
            AuthorId = authorId;
        }
    }
}
