using bsvd.shopping.application.Catalog.Domain;
using System.Collections.Generic;

namespace bsvd.shopping.application.Services
{
    public interface IproductRepo
    {
        void CreateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetAProductByID(int id);
        Product UpdateProduct(int id,Product product);
        void Delete(int id);

    }
}
