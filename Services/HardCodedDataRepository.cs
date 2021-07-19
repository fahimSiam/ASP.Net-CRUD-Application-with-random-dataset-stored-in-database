using Activity2a.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2a.Services
{
    
    public class HardCodedDataRepository : IProductDataServices
    {
       static List<ProductModel> productsList = new List<ProductModel>();


        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            if (productsList.Count == 0)
            {
                productsList.Add(new ProductModel { Id = 1, Name = "Mouse Pad", Price = 4.99m, Description = "this is the viper mini" });
                productsList.Add(new ProductModel { Id = 2, Name = "Web Cam", Price = 7.99m, Description = "used to stream games with your face" });
                productsList.Add(new ProductModel { Id = 3, Name = "SSD", Price = 10.99m, Description = "Your Games load faster" });
                productsList.Add(new ProductModel { Id = 4, Name = "Keyboard", Price = 8.99m, Description = "Counter Strafe better" });


                for (int i = 0; i < 100; i++)
                {
                    productsList.Add(new Faker<ProductModel>()
                        .RuleFor(p => p.Id, i + 5)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(500))
                        .RuleFor(p => p.Description, f => f.Rant.Review())
                        );

                }
            }
            return productsList;
        }

        public ProductModel GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProduct(string searchItem)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
