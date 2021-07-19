using Activity2a.Models;
using Activity2a.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2a.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductsDAO products= new ProductsDAO();
            return View(products.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            ProductsDAO products = new ProductsDAO();
            List<ProductModel> productList = products.SearchProduct(searchTerm);
            return View("index", productList);
        }

        public IActionResult ShowDetails(int Id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(Id);
            return View(foundProduct);
        }

        public IActionResult Edit(int Id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(Id);
            return View("ShowEdit", foundProduct);
        }


        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }




        public IActionResult Insert()
        {
            return View("InsertForm");
        }

        public IActionResult ProcessInsert(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Insert(product);
            return View("Index", products.GetAllProducts());
        }




        public IActionResult Delete(int Id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(Id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }

       

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult Message()
        {
            return View();
        }
        public IActionResult Welcome(string name, int secretNumber = 13)
        {
            ViewBag.name = name;
            ViewBag.secret = secretNumber;
            return View();
        }
        public IActionResult Orders(string name)
        {
            ViewBag.name = name;
            return View();
        }
    }
}
