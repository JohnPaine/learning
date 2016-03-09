using System;

namespace ProductsDomain
{
    public class DiscountedProduct
    {
        public DiscountedProduct(string name, decimal unitPrice, int productId) {
            if (null == name)
                throw new ArgumentNullException(nameof(name));

            Name = name;
            UnitPrice = unitPrice;
            ProductId = productId;
        }

        public string Name { get; }

        public decimal UnitPrice { get; }

        public int ProductId { get; }
    }
}