using System;
using System.Linq;
using System.Security.Principal;

namespace ProductsDomain
{
    public class ProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository) {
            if (null == repository)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        public IQueryable<DiscountedProduct> GetFeaturedProducts(IPrincipal user) {
            if (null == user)
                throw new ArgumentNullException(nameof(user));

            return from p in _repository.Products select p.ApplyDiscountFor(user);
        }
    }
}