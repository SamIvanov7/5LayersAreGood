using Library.Application.Domain.Bocks.Queries.GetBocks;
using Library.Core.Domain.Bocks.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Domain.Bocks.Queries.GetBocks;

public class GetBocksQueryHandler : IRequestHandler<GetBocksQuery, BockDto[]>
{
    private readonly IBocksRepository _bocksRepository;

    public GetBocksQueryHandler(IBocksRepository bocksRepository)
    {
        _bocksRepository = bocksRepository;
    }

    public async Task<BockDto[]> Handle(GetBocksQuery request, CancellationToken cancellationToken)
    {
        var bocks = await _bocksRepository.GetBocksAsync(request.Page, request.PageSize, cancellationToken);
        return bocks.Select(bock => new BockDto
        {
            Id = bock.Id,
            Title = bock.Title,
            AuthorId = bock.AuthorId,
            Genre = bock.Genre
        }).ToArray();
    }
}
