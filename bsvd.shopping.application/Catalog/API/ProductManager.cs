using bsvd.shopping.application.Catalog.Domain;
using bsvd.shopping.application.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace bsvd.shopping.application.Catalog.API
{
    public class ProductManager : ApiController
    {
        private IproductRepo _repository;

        public ProductManager(IproductRepo repository)
        {
            _repository = repository;
        }
        // GET api/<controller>
        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        // GET api/<controller>/5
        public Product GetAProductByID(int id)
        {
            var products = _repository.GetAProductByID(id);
            return products;
        }

        // POST api/<controller>
        public void Post([FromBody] Product product)
        {
            _repository.CreateProduct(product);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id, Product product)
        {
            product.ProductId = id;
            _repository.Delete(id);
        }
    }
}