using BurgerPlace.Models;

namespace BurgerPlace.ViewModel
{
    public class ItemListViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public string CategoriaAtual { get; set; }
        public IEnumerable<Item> Itens { get; internal set; }

    }
}