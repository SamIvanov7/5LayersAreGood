using Library.Application.Domain.Bocks.Commands.CreateBock;
using Library.Core.Common;
using Library.Core.Domain.Bocks.Common;
using Library.Core.Domain.Bocks.Data;
using Library.Core.Domain.Bocks.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Domain.Bocks.Commands.CreateBock;

public class CreateBockCommandHandler : IRequestHandler<CreateBockCommand, Guid>
{
    private readonly IBocksRepository _bocksRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBockCommandHandler(IBocksRepository bocksRepository, IUnitOfWork unitOfWork)
    {
        _bocksRepository = bocksRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateBockCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateBockData(
            command.Title,
            command.AuthorId,
            command.Genre);

        var bock = Bock.Create(data);

        await _bocksRepository.AddAsync(bock, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return bock.Id;
    }
}
