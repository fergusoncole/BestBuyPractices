using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyPractices
{
    public class ProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string newName, double newPrice, int newCategoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                new { name = newName, price = newPrice, categoryID = newCategoryID });  
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products");
        }

        public void UpdateProductName(int newProductID, string newUpdatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @product_id;",
                new { updatedName = newUpdatedName, product_id = newProductID });
        }
        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM products WHERE ProductID = @product_id;",
                new { product_id = productID });
        }

    }
}
