using Library.Application.Domain.Bocks.Commands.AddBockAuthor;
using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Bocks.Common;
using Library.Core.Domain.Bocks.Data;
using Library.Core.Domain.Bocks.Models;
using MediatR;

namespace Library.Application.Domain.bocks.Commands.AddBockAuthor
{
    public class AddBockAuthorCommandHandler : IRequestHandler<AddBockAuthorCommand>
    {
        private readonly IAuthorMustExistChecker _authorMustExistChecker;
        private readonly IBockMustExistChecker _bockMustExistChecker;
        private readonly IBocksAuthorsRepository _bockAuthorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddBockAuthorCommandHandler(
            IAuthorMustExistChecker authorMustExistChecker,
            IBockMustExistChecker bockMustExistChecker,
            IBocksAuthorsRepository bockAuthorRepository,
            IUnitOfWork unitOfWork)
        {
            _authorMustExistChecker = authorMustExistChecker;
            _bockMustExistChecker = bockMustExistChecker;
            _bockAuthorRepository = bockAuthorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddBockAuthorCommand command, CancellationToken cancellationToken)
        {
            var data = new CreateBockAuthorData(command.BockId, command.AuthorId);
            var bockAuthor = await BockAuthor.Create(
                _authorMustExistChecker,
                _bockMustExistChecker,
                data);

            _bockAuthorRepository.Add(bockAuthor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
