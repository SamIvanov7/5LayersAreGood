using Library.Api.Common;
using Library.Api.Constants;
using Library.Api.Domain.Bocks.Requests;
using Library.Application.Domain.Bocks.Commands.CreateBock;
using Library.Application.Domain.Bocks.Commands.DeleteBock;
using Library.Application.Domain.Bocks.Commands.UpdateBock;
using Library.Application.Domain.Bocks.Queries.GetBockDetails;
using Library.Application.Domain.Bocks.Queries.GetBocks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using PagesResponses;


namespace Library.Api.Domain.Bocks;

[Route(Routes.Bocks)]
public class BocksController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public BocksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<BockDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBocks(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var bocks = await _mediator.Send(new GetBocksQuery(page, pageSize), cancellationToken);
        return Ok(bocks);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BockDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBock(
        [FromRoute][Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetBockDetailsQuery(id);
        var bock = await _mediator.Send(query, cancellationToken);
        return bock != null ? Ok(bock) : NotFound();
    }

    [HttpPost]
    [ProducesResponseType(typeof(BockDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBock(
        [FromBody][Required] CreateBockRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateBockCommand(request.Title, request.AuthorId, request.Genre);
        var bockId = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetBock), new { id = bockId }, bockId);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBock(
        [FromRoute][Required] Guid id,
        [FromBody][Required] UpdateBockRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateBockCommand(id, request.Title, request.AuthorId, request.Genre);
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBock(
        [FromRoute][Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteBockCommand(id);
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }
}
