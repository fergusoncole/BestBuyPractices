using BestBuyPractices;
using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var productRepo = new ProductRepository(conn);

//productRepo.CreateProduct("NEW PRODUCT TEST #1", 37.50, 10);
//productRepo.UpdateProductName(940, "UPDATED PRODUCT 1");
productRepo.DeleteProduct(940);

foreach (var product in productRepo.GetAllProducts())
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine();
    Console.WriteLine();

}














//var departmentRepo = new DepartmentRepository(conn);

//departmentRepo.InsertDepartment("TEST1");
//departmentRepo.UpdateDepartment(6, "UPDATED TEST1");
//departmentRepo.DeleteDepartment(6);

//var departments = departmentRepo.GetAllDepartments();

//foreach (var department in departments)
//{
//    Console.WriteLine(department.DepartmentID);
//    Console.WriteLine(department.Name);
//    Console.WriteLine();
//    Console.WriteLine();
//}