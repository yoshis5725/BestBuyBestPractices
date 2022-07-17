using System.Data;
using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);


// creating a products depository instance and passing in the connection string from appsettings.json
var productsRepo = new Dapper_ProductRepository(conn);

// Products Db actions
productsRepo.CreateProduct("Test Product", 200.34, 10);
productsRepo.DeleteProduct(940);
productsRepo.UpdateProduct(941, "Updated Test Name");

var products = productsRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"Name: {product.Name}\nPrice: {product.Price}\nCategory Id: {product.CategoryId}\n\n");
}
