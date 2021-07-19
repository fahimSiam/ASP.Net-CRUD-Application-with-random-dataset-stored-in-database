using Activity2a.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2a.Services
{
    public class HardCodedMovieRepository : MovieListInterface
    {
        static List<MovieModel> MovieList = new List<MovieModel>();
        public int Delete(MovieModel product)
        {
            throw new NotImplementedException();
        }

     
        public List<MovieModel> GetAllProducts()
        {
            for (int i = 0; i < 100; i++)
            {
                MovieList.Add(new Faker<MovieModel>()
                    .RuleFor(p => p.Id, i)
                    .RuleFor(p => p.MovieName, f => f.Company.CompanyName())
                    .RuleFor(p => p.Rating, f => f.Random.Decimal(10))
                    .RuleFor(p => p.Genre, f => f.Random.Words()));
            }

            return MovieList;
        }

        public ProductModel GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(MovieModel product)
        {
            throw new NotImplementedException();
        }

        public List<MovieModel> SearchProduct(string searchItem)
        {
            throw new NotImplementedException();
        }

        public int Update(MovieModel product)
        {
            throw new NotImplementedException();
        }
    }
}
