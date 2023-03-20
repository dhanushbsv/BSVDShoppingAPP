using bsvd.shopping.application.Catalog.Domain;
using bsvd.shopping.application.Services;
using System.Collections.Generic;
using System.Linq;

namespace bsvd.shopping.application.Catalog.Data
{

    /*public class ProductRepo : IproductRepo
    {
        string conString = ConfigurationManager.ConnectionStrings["ShoppingDbEntities"].ToString();



        //Create Product
        public bool CreateProduct(Product product)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_createProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Name", product.Name);
                command.Parameters.AddWithValue("Description", product.Description);
                command.Parameters.AddWithValue("ImageURL", product.ImageURL);
                command.Parameters.AddWithValue("Model", product.Model);
                command.Parameters.AddWithValue("Price", product.Price);
                command.Parameters.AddWithValue("SubCategoryId", product.SubCategoryId);

                connection.Open();
                id = command.ExecuteNonQuery();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get product By Id
        public List<Product> GetAProductByID(int ProductId)
        {
            List<Product> ProductsList = new List<Product>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_getProductById";
                command.Parameters.AddWithValue("@ProductId", ProductId);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();

                connection.Open();
                sqlDA.Fill(dtProducts);


                foreach (DataRow dr in dtProducts.Rows)
                {
                    ProductsList.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        Name = dr["Name"].ToString(),
                        Model = dr["Model"].ToString(),
                        Description = dr["Description"].ToString(),
                        ImageURL = dr["ImageURL"].ToString(),
                        Price = Convert.ToInt32(dr["Price"]),
                        SubCategoryId = Convert.ToInt32(dr["SubCategoryId"])
                    });
                }
            }
            return ProductsList;
        }


        //Update Product

        public bool UpdateProduct(Product product)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_updateProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("ProductId", product.ProductId);
                command.Parameters.AddWithValue("Name", product.Name);
                command.Parameters.AddWithValue("Description", product.Description);
                command.Parameters.AddWithValue("ImageURL", product.ImageURL);
                command.Parameters.AddWithValue("Model", product.Model);
                command.Parameters.AddWithValue("Price", product.Price);
                command.Parameters.AddWithValue("SubCategoryId", product.SubCategoryId);

                connection.Open();
                i = command.ExecuteNonQuery();
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //delete Product
        public void DeleteProduct(int productid)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_deleteProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", productid);

                connection.Open();
                command.ExecuteNonQuery();

            }


        }


        //get all products

        public List<Product> GetAllProducts()
        {
            List<Product> productsList = new List<Product>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_getAllProducts";

                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();

                connection.Open();
                sqlDA.Fill(dtProducts);

                foreach (DataRow dr in dtProducts.Rows)
                {
                    productsList.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        Name = dr["Name"].ToString(),
                        Model = dr["Model"].ToString(),
                        Description = dr["Description"].ToString(),
                        ImageURL = dr["ImageURL"].ToString(),
                        Price = Convert.ToInt32(dr["Price"]),
                        SubCategoryId = Convert.ToInt32(dr["SubCategoryId"])
                    });
                }
            }
            return productsList;
        }
    }*/

    public class ProductRepo : IproductRepo
    {
        public ShoppingDBContext db = new ShoppingDBContext();
        public void CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.ProductId == id);
            if(product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products;
        }

        public Product GetAProductByID(int id)
        {
            return db.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var pdt = db.Products.SingleOrDefault(x => x.ProductId == id);
            pdt.Name = product.Name;
            pdt.Model = product.Model;
            pdt.ImageURL = product.ImageURL;
            pdt.Price = product.Price;
            pdt.SubCategoryId = product.SubCategoryId;
            pdt.Description = product.Description;
            db.SaveChanges();
            return pdt;
        }
        
    }
}