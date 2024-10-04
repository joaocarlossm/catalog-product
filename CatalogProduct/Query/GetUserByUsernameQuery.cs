namespace CatalogProduct.Queries
{
    public class GetUserByUsernameQuery
    {
        public string Username { get; }

        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
