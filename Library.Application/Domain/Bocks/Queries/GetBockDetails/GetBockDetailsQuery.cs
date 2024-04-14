using MediatR;
using Library.Application.Domain.Bocks.Dtos;  
using Library.Core.Domain.Bocks.Common;

namespace Library.Application.Domain.Bocks.Queries.GetBockDetails;
public class GetBockDetailsQuery : IRequest<BockDetailsDto>
{
    public Guid BockId { get; }

    public GetBockDetailsQuery(Guid bockId)
    {
        BockId = bockId;
    }
}

public class GetBockDetailsQueryHandler : IRequestHandler<GetBockDetailsQuery, BockDetailsDto>
{
    private readonly IBocksRepository _bocksRepository;

    public GetBockDetailsQueryHandler(IBocksRepository bocksRepository)
    {
        _bocksRepository = bocksRepository;
    }

    public async Task<BockDetailsDto> Handle(GetBockDetailsQuery request, CancellationToken cancellationToken)
    {
        var bock = await _bocksRepository.FindAsync(request.BockId, cancellationToken);

        if (bock == null)
        {
            throw new KeyNotFoundException("Bock not found.");
        }

        return new BockDetailsDto
        {
            Id = bock.Id,
            Title = bock.Title,
            AuthorId = bock.AuthorId,
            Genre = bock.Genre
        };
    }
}
