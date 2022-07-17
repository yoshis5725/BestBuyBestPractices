using System.Data;
using Dapper;

namespace BestBuyBestPractices;

public class Dapper_ProductRepository : IProductRepository
{
    // fields
    private readonly IDbConnection _connection;
    
    
    // constructor
    public Dapper_ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    
    // methods
    
    /// <summary>
    /// Returning all products from the Db
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM Products;");
    }

    /// <summary>
    /// Creating a new product
    /// </summary>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="categoryId"></param>
    public void CreateProduct(string name, double price, int categoryId)
    {
        _connection.Execute("INSERT INTO Products (Name, Price, CategoryId) VALUES (@name, @price, @categoryId);",
            new {name, price, categoryId});
    }

    /// <summary>
    /// Deleting a product based off of the product Id
    /// </summary>
    /// <param name="productId"></param>
    public void DeleteProduct(int productId)
    {
        _connection.Execute("DELETE From Products WHERE productId = @productId;",
            new { productId });
    }

    /// <summary>
    /// Updating the product name based off of the product Id
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="updatedName"></param>
    public void UpdateProduct(int productId, string updatedName)
    {
        _connection.Execute("UPDATE Products SET name = @updatedName WHERE productId = @productId;", 
            new {updatedName, productId});
    }
}