using Activity2a.Models;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2a.Services
{
    public class ProductsDAO : IProductDataServices
    {
        string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        
        
        public int Delete(ProductModel product)
        {
            int newIdNumber = -1;
            string sqlStatement = "DELETE FROM dbo.Products WHERE Id= @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", product.Id);
                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            return newIdNumber;
        }






        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();
            string sqlStatement = "SELECT * FROM dbo.Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel { 
                            Id = (int)reader[0], 
                            Name = (string)reader[1], 
                            Price = (decimal)reader[2], 
                            Description = (string)reader[3] 
                        });
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            return foundProducts;
        }






        public ProductModel GetProductById(int Id)
        {
            ProductModel foundProduct = null;
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProduct=new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        };
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            return foundProduct;
        }






        public int Insert(ProductModel product)
        {
            int newIdNumber = -1;
            string sqlStatement = "INSERT INTO dbo.Products VALUES (@Name, @Price, @Description)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            return newIdNumber;
        }




        public List<ProductModel> SearchProduct(string searchTerm)
        {

            List<ProductModel> foundProducts = new List<ProductModel>();
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name Like @Name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        });
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            return foundProducts;

        }





        public int Update(ProductModel product)
        {
            int newIdNumber = -1;
            string sqlStatement = "UPDATE dbo.Products SET Name= @Name, Price = @Price, Description =@Description WHERE Id= @Id" ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Id", product.Id);
                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            return newIdNumber;
        }
    }
}
