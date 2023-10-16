using BurgerPlace.Models;
using BurgerPlace.Repositories.Interfaces;
using BurgerPlace.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MaisSabor.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRespository;
        public ItemController(IItemRepository itemRespository)
        {
            _itemRespository = itemRespository;
        }
        public IActionResult List(string categoria)
        {
            IEnumerable<Item> itens;
            var categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                itens = _itemRespository.Itens.OrderBy(m => m.ItemId);
                categoriaAtual = "Todos os itens";
            }
            else
            {
                itens = _itemRespository.Itens.Where(m =>
                m.Categoria.Nome.Equals(categoria)).OrderBy(m => m.ItemId);

                categoriaAtual = categoria;
            }
            var itemListViewMovel = new ItemListViewModel
            {
                Items = itens,
                CategoriaAtual = categoriaAtual
            };
            return View(itemListViewMovel);
        }
        public IActionResult Details(int itemId)
        {

            var Item = _itemRespository.Itens.FirstOrDefault(m =>

            m.ItemId == itemId);

            return View(Item);
        }
        public IActionResult Search(string searchString)
        {

            IEnumerable<Item> items;
            string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(searchString))
            {
                items = _itemRespository.Itens.OrderBy(m => m.Nome);
                categoriaAtual = "Todos os Itens";
            }
            else
            {
                items = _itemRespository.Itens.Where(m =>
                m.Nome.ToLower() == searchString.ToLower()).OrderBy(m => m.Nome);

                if (items.Any())
                {
                    categoriaAtual = "Itens";
                }
                else
                {
                    categoriaAtual = "Nada encontrado";
                }
            }
            return View("~/Views/Movel/List.cshtml", new
            ItemListViewModel
            {
                CategoriaAtual = categoriaAtual,
                Items = items
            });

        }
    }
}


