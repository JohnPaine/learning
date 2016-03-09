using System.Linq;

namespace ProductsDomain
{
    public interface IRepository
    {
        #region Product

        IQueryable<Product> Products { get; }

//        bool CreateProduct(Product instance);
//
//        bool UpdateProduct(Product instance);
//
//        bool RemoveProduct(int idProduct);

        #endregion
    }
}