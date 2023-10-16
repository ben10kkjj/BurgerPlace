using BurgerPlace.Context;
using BurgerPlace.Models;
using BurgerPlace.Repositories.Interfaces;

namespace BurgerPlace.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categoria;

    }
}