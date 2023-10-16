using BurgerPlace.Models;

namespace BurgerPlace.Repositories.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> Itens { get; }
        IEnumerable<Item> ItensEmDestaque { get; }
        object Items { get; }


        Item GetItemById(int itemId);
    }
}