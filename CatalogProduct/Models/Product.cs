namespace CatalogProduct.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required decimal Preco { get; set; }
        public required string Descricao { get; set; }
    }
}