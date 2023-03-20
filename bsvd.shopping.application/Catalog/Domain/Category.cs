using System.Collections.Generic;

namespace bsvd.shopping.application.Catalog.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<SubCategory> SubCategory { get; set; }
    }
}