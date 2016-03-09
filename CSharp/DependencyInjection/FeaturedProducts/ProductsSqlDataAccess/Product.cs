namespace ProductsSqlDataAccess
{
    public partial class Product
    {
        public ProductsDomain.Product ToDomainProduct() {
            return new ProductsDomain.Product {
                Name = Name,
                UnitPrice = UnitPrice,
                ProductId = ProductId
            };
        }
    }
}