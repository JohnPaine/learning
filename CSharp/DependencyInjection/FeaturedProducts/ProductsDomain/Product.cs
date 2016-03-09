using System.Security.Principal;

namespace ProductsDomain
{
    public class Product
    {
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int ProductId { get; set; }

        public DiscountedProduct ApplyDiscountFor(IPrincipal user) {
            var discount = user.IsInRole("PreferedCustomer") ? .95m : 1;
            return new DiscountedProduct(Name, UnitPrice * discount, ProductId);
        }
    }
}