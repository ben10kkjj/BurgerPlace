namespace BurgerPlace.Models
{
    public class Categoria
    {
        public int CategoriaId {get;set;}

        public string Nome {get;set;}
        public List<Item> Item {get;set;}

    }
}