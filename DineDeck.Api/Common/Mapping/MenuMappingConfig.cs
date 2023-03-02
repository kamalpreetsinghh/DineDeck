using DineDeck.Application.Menus.Commands.CreateMenu;
using DineDeck.Contracts.Menus;
using DineDeck.Domain.MenuAggregate;
using Mapster;

using MenuSection = DineDeck.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = DineDeck.Domain.MenuAggregate.Entities.MenuItem;

namespace DineDeck.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.HostId, src => src.HostId.Value.ToString())
            .Map(dest => dest.AverageRating, src => src.AverageRating)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(x => x.Value.ToString()))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(x => x.Value.ToString()));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
