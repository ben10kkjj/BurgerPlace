using BurgerPlace.Context;
using Microsoft.EntityFrameworkCore;

namespace BurgerPlace.Models
{
    public class Carrinho
    {
        private readonly AppDbContext _context;
        public Carrinho(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoId { get; set; }
        public List<CarrinhoItem> CarrinhoItens { get; set; }
        public static Carrinho GetCarrinhoCompra(IServiceProvider
        services)
        {

            ISession session =

            services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string carrinhoId = session.GetString("CarrinhoId") ??

            Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);
            return new Carrinho(context)
            {
                CarrinhoId = carrinhoId
            };

        }
        public void AdicionarItemCarrinho(Item item)
        {
            var carinhoItem = _context.Items.SingleOrDefault(s =>   s.Item.ItemId == item.ItemId && s.Carrinho == CarrinhoId);

            if (carinhoItem == null)
            {
                carinhoItem = new CarrinhoItem
                {
                    Carrinho = CarrinhoId,
                    Item = item,
                    Quantidade = 1
                };
                _context.Items.Add(carinhoItem);
            }
            else
            {
                carinhoItem.Quantidade++;
            }
            _context.SaveChanges();
        }
        public int RemoverItemDoCarrinhoCompra(Item item)
        {
            var carrinhoQuantidade = 0;
            var carinhoItem = _context.Items.SingleOrDefault(s =>   s.Item.ItemId == item.ItemId && s.Carrinho == CarrinhoId);

            if (carinhoItem != null)
            {
                if (carinhoItem.Quantidade > 1)
                {
                    carinhoItem.Quantidade--;
                    carrinhoQuantidade = carinhoItem.Quantidade;
                }
                else
                {
                    _context.Items.Remove(carinhoItem);
                }

            }
            _context.SaveChanges();
            return carrinhoQuantidade;
        }
        public List<CarrinhoItem> GetCarrinhoCompraItems()
        {
            return CarrinhoItens ?? _context.Items.Where(c => c.Carrinho == CarrinhoId).Include(s => s.Item).ToList();
        }
        public void LimparCarrinho()
        {
            var carrinhoCompra = _context.Items.Where(c =>

        c.Carrinho == CarrinhoId);

            _context.Items.RemoveRange(carrinhoCompra);
            _context.SaveChanges();
        }
        public double GetCarrinhoCompraTotal()
        {
            List<double> total = _context.Items.Where(_c =>

            _c.Carrinho == CarrinhoId).Select(c =>
            c.Quantidade * c.Item.Preco).ToList();
            double totalr = 0;
            foreach (double t in total)
            {
                totalr = totalr + t;
            }
            return totalr;
        }

        internal void RemoverItemDoCarrinhoCompra(object itemSelecionado)
        {
            throw new NotImplementedException();
        }

    }
}