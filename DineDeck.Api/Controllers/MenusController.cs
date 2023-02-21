using DineDeck.Application.Menus.Commands.CreateMenu;
using DineDeck.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DineDeck.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public MenusController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await _mediator.Send(command);
        if (createMenuResult.IsFailed)
        {
            return BadRequest(createMenuResult.Errors);
        }
        var result = _mapper.Map<MenuResponse>(createMenuResult.Value);
        return Ok(result);
    }

}