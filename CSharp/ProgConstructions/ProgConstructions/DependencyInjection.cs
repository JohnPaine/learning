using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal class DependencyInjection
    {
        private class ProductRepository
        {
            ProductRepository() {
                for (var i = 0; i < 10; i++) {
                    products.Add($"Some product {i}");
                }
            }

            public List<string> products { get; private set; }
        }
        
        /// <summary>
        /// Control Freak anti-pattern
        /// </summary>
        class ProductService
        {
            private readonly ProductRepository repository;

            /// <summary>
            /// Control freak classes control every dependency explicitly (via new keyword)
            /// Dependency injection pattern helps to avoid such explicit control
            /// </summary>
            /// <param name="repository"></param>
            public ProductService(ProductRepository repository) {
                if (repository == null)
                    throw new ArgumentNullException(nameof(repository));
                this.repository = repository;
            }
        }

    }
}
