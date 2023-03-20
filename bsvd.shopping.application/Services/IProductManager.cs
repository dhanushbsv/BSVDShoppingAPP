using bsvd.shopping.application.Catalog.Domain;
using System.Collections.Generic;
using System.Web.Http;

namespace bsvd.shopping.application.Services
{
    public interface IProductManager
    {
        IEnumerable<Product> GetAllProducts();
        Product GetAProductByID(int id);
        void Post([FromBody] Product product);

        void Delete(int id, Product product);

    }
}
