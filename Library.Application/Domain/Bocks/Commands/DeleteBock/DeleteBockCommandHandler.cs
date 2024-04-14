using Library.Application.Domain.Bocks.Commands.DeleteBock;
using Library.Core.Common;
using Library.Core.Domain.Bocks.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Domain.Bocks.Commands.DeleteBock;

public class DeleteBockCommandHandler : IRequestHandler<DeleteBockCommand>
{
    private readonly IBocksRepository _bocksRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBockCommandHandler(IBocksRepository bocksRepository, IUnitOfWork unitOfWork)
    {
        _bocksRepository = bocksRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteBockCommand command, CancellationToken cancellationToken)
    {
        var bock = await _bocksRepository.FindAsync(command.BockId, cancellationToken);

        if (bock == null)
        {
            throw new InvalidOperationException("bock not found.");
        }

        _bocksRepository.Delete(new[] { bock });
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value; // MediatR way to signify end of handling when no data needs to be returned
    }
}
