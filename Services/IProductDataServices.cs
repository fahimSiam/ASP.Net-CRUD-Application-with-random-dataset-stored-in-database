using Activity2a.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2a.Services
{
    interface IProductDataServices
    {
        List<ProductModel> GetAllProducts();
        List<ProductModel> SearchProduct(string searchItem);
        ProductModel GetProductById(int Id);
        int Insert(ProductModel product);
        int Delete(ProductModel product);
        int Update(ProductModel product);
    }
}
