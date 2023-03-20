namespace bsvd.shopping.application.Catalog.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }


        public string Model { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}