using System.Collections.Generic;

namespace bsvd.shopping.application.Catalog.Domain
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}