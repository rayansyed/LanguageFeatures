using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using W3_LanguageFeatures1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace W3_LanguageFeatures1.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/


        private bool CheapProduct(Product product)
        {
            return product.Price < 10;
        }

        public IActionResult Index()
        {
            var results = new List<string>();
            var productList = Repository.GetProducts().Filter(CheapProduct);
            var lessThan1000List = Repository.GetProducts().Filter(p => p.Price<=1000);
            var startWithI = Repository.GetProducts().Filter(p => p.Name.StartsWith("i"));
            var cheapIphones = Repository.GetProducts()
                .Filter(p => p.Price <= 1200)
                .Filter(p => p.Name.ToLower().Contains("iPhone"))
                .Filter(p => p.Category.ToLower().Equals("phones"));

            var cheapProducts = from p in Repository.GetProducts()
                                where p.Price < 10
                                orderby p.Price descending
                                select new {productName = p.Name};

            var cheapProducts2 = Repository.GetProducts()
                .Where(p => p.Price < 10)
                .OrderByDescending(p => p.Price)
                .Select(p => p);
             
           
            var cart = new ShoppingCart
            {
                Products = productList
            };


            //var productList = Repository.GetProducts().FilterByPrice(1500).FilterByName("iphone"))

            foreach (var product in productList)
            {

                var name = product.Name;
                var price = product.Price;
                //question mark checks if mostRelatedProductName is Null, ?? = else
                var mostRelatedProductName = product.RelatedProduct?.Name ?? "<none>";

                results.Add($"Name: {name} - Price: ${price} - Most Related Product: {mostRelatedProductName}");



            }

            results.Add($"Total amount of all Prodcuts is ${cart.CalculateTotal()}");

            return View(results);
        }
    }
}
