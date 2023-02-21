using DineDeck.Application.Common.Interfaces.Persistence;
using DineDeck.Domain.HostAggregate.ValueObjects;
using DineDeck.Domain.MenuAggregate;
using DineDeck.Domain.MenuAggregate.Entities;
using FluentResults;
using MediatR;

namespace DineDeck.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Result<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<Result<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var menu = Menu.Create(
            name: request.Name,
            description: request.Description,
            hostId: HostId.Create(request.HostId),
            menuSections: request.Sections.ConvertAll(section => MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description)))));

        _menuRepository.Add(menu);

        return menu;
    }
}
