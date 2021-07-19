using Activity2a.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2a.Services
{
    interface MovieListInterface
    {
        List<MovieModel> GetAllProducts();
        List<MovieModel> SearchProduct(string searchItem);
        ProductModel GetProductById(int Id);
        int Insert(MovieModel product);
        int Delete(MovieModel product);
        int Update(MovieModel product);
    }
}
