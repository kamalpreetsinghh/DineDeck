using DineDeck.Domain.MenuAggregate;

namespace DineDeck.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}