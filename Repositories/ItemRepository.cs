using BurgerPlace.Context;


using BurgerPlace.Models;

using BurgerPlace.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace BurgerPlace.Repositories
{
    public class ItemRepository:IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> Itens => _context.Item.Include(c =>
        c.Categoria);
        public IEnumerable<Item> ItensEmDestaque =>
        _context.Item.Where(m => m.Destaque).Include(c => c.Categoria);

        public object Items => throw new NotImplementedException();


        public Item GetItemById(int itemId)
        {
            return _context.Item.FirstOrDefault(m => m.ItemId == itemId);
        }
    }
}