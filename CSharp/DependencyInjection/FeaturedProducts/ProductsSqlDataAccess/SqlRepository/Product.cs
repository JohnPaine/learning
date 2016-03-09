using System.Collections.Specialized;
using System.Linq;
using ProductsDomain;

namespace ProductsSqlDataAccess
{
    public partial class SqlRepository
    {
        public IQueryable<ProductsDomain.Product> Products => from p in Db.Products select new ProductsDomain.Product {
            Name = p.Name,
            UnitPrice = p.UnitPrice,
            ProductId = p.ProductId
        };

        public bool CreateProduct(Product instance) {
            if (instance.ProductId != 0) {
                return false;
            }

            Db.Products.InsertOnSubmit(instance);
            Db.Products.Context.SubmitChanges();
            return true;
        }

        public bool UpdateProduct(Product instance) {
            var cache = Db.Products.FirstOrDefault(p => p.ProductId == instance.ProductId);
            if (cache == null) {
                return false;
            }

            //TODO : Update fields for Product
            Db.Products.Context.SubmitChanges();
            return true;
        }

        public bool RemoveProduct(int idProduct) {
            var instance = Db.Products.FirstOrDefault(p => p.ProductId == idProduct);
            if (instance == null) {
                return false;
            }

            Db.Products.DeleteOnSubmit(instance);
            Db.Products.Context.SubmitChanges();
            return true;
        }
    }
}