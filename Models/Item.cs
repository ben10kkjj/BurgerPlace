namespace BurgerPlace.Models
{
    public class Item
    {
        public int ItemId {get;set;}
        public string Nome {get;set;}
        public string DescricaoCurta {get;set;}
        public string DescricaoDetalhada {get;set;}
        public string ImagemUrl {get;set;}
        public double Preco {get;set;}
        public bool Ativo {get;set;}
        public bool Destaque {get;set;}
        public int CategoriaId {get;set;}
        public virtual Categoria Categoria{get;set;}
        public bool EmDestaque { get; internal set; }

    }
}