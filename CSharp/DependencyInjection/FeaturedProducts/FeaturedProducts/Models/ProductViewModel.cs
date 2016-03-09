using ProductsDomain;

namespace FeaturedProducts.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(DiscountedProduct product) {
            Name = product.Name;
            UnitPrice = product.UnitPrice;
            ProductId = product.ProductId;
        }

        public string Name { get; set; }

        public string SummaryText => $"{Name} ({UnitPrice:C})";

        public decimal UnitPrice { get; set; }

        public int ProductId { get; }
    }
}