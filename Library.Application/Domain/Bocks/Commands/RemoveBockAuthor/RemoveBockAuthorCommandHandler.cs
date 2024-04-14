using Library.Application.Domain.Bocks.Commands.RemoveBockAuthor;
using Library.Core.Common;
using Library.Core.Domain.Bocks.Common;
using MediatR;

namespace Library.Application.Domain.Bocks.Commands.RemoveBockAuthor
{
    public class RemoveBockAuthorCommandHandler : IRequestHandler<RemoveBockAuthorCommand>
    {
        private readonly IBocksAuthorsRepository _bockAuthorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveBockAuthorCommandHandler(
            IBocksAuthorsRepository bockAuthorRepository,
            IUnitOfWork unitOfWork)
        {
            _bockAuthorRepository = bockAuthorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveBockAuthorCommand command, CancellationToken cancellationToken)
        {
            var bockAuthor = await _bockAuthorRepository.FindBockAuthorAsync(command.BockId, command.AuthorId);
            _bockAuthorRepository.Delete(bockAuthor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
