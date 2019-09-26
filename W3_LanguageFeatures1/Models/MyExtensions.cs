using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace W3_LanguageFeatures1.Models
{
    // public delegate bool ProductFilter(Product p);

    

    public static class MyExtensions
    {

        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("https://www.apress.com/us");
            return httpMessage.Content.Headers.ContentLength;
        }

        public static decimal CalculateTotal(this ShoppingCart cart)
        {
            decimal total = 0;

            foreach (var product in cart.Products)
            {
                total += product.Price;
            }
            return total;
        }


        public static IEnumerable<Product> FilterByPrice (this IEnumerable<Product> products, decimal maxPrice)
        {
            //var filteredProdcuts = new List<Product>();

            foreach (var product in products)
            {
                if (product.Price <= maxPrice)
                    yield return product;
            }

            //return filteredProducts;
        }


        //filter by name 
        public static IEnumerable<Product> FilterByName(this IEnumerable<Product> products, string name)
        {
            var filteredProdcuts = new List<Product>();

            foreach (var product in products)
            {
                if (product.Name.ToLower().StartsWith(name.ToLower()))
                {
                    filteredProdcuts.Add(product);
                }
            }

            return filteredProdcuts;
        }


        //public static IEnumerable<Product> Filter(this IEnumerable<Product> products, ProductFilter selector)
        //{
        //    //var filteredProdcuts = new List<Product>();

        //    foreach (var product in products)
        //    {
        //        if (selector(product))
        //            yield return product;
        //    }

        //    //return filteredProducts;
        //}


        public static IEnumerable<Product> Filter(this IEnumerable<Product> products, Func<Product, bool> selector) //Func<Product as argument,return bool>
        {
            //var filteredProdcuts = new List<Product>();

            foreach (var product in products)
            {
                if (selector(product))
                    yield return product;
            }

            //return filteredProducts;
        }

    }
}
