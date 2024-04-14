using MediatR;
using System;

namespace Library.Application.Domain.Bocks.Commands.DeleteBock;

public class DeleteBockCommand : IRequest
{
    public Guid BockId { get; private set; }

    public DeleteBockCommand(Guid bockId)
    {
        BockId = bockId;
    }
}
