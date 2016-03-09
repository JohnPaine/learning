using System.Collections.Generic;

namespace FeaturedProducts.Models
{
    public class FeaturedProductsViewModel
    {
        private readonly List<ProductViewModel> _products;

        public FeaturedProductsViewModel() {
            _products = new List<ProductViewModel>();
        }

        public IList<ProductViewModel> Products => _products;
    }
}