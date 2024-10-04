namespace CatalogProduct.Queries
{
    public class GetProductByIdQuery
    {
        public int Id { get; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}