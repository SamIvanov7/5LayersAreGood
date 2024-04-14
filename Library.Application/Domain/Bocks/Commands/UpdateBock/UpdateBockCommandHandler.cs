// FilePath: Library.Application/Domain/bocks/Commands/Updatebock/UpdatebockCommandHandler.cs
using Library.Core.Domain.Bocks.Common;
using Library.Core.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Domain.Bocks.Commands.UpdateBock
{
    public class UpdateBockCommandHandler : IRequestHandler<UpdateBockCommand>
    {
        private readonly IBocksRepository _bocksRepository;

        public UpdateBockCommandHandler(IBocksRepository bocksRepository)
        {
            _bocksRepository = bocksRepository;
        }

        public async Task<Unit> Handle(UpdateBockCommand request, CancellationToken cancellationToken)
        {
            var bock = await _bocksRepository.FindAsync(request.Id, cancellationToken);

            if (bock == null)
            {
                throw new NotFoundException("bock not found.");
            }

            // Update properties
            bock.Title = request.Title;
            bock.AuthorId = request.AuthorId;
            bock.Genre = request.Genre;

            // Assuming the repository handles the update internally
            _bocksRepository.UpdateAsync(bock);

            object value = await _bocksRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value; // MediatR way to say "completed"
        }
    }
}
