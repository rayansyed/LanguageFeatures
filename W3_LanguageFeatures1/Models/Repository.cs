using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace W3_LanguageFeatures1.Models
{
    public class Repository
    {
        public static IEnumerable<Product> GetProducts()
        {

            var iPhone = new Product
            {
                Name = "iPhone 11",
                Price = 900

            };

            return new List<Product>
            {
                new Product{
                    Name = "iPhone XR 128",
                    Price = 599

                },

                new Product{
                    Name = "iPhone 11 Pro Max",
                    Price = 1200,
                    RelatedProduct = iPhone

                },


                new Product{
                    Name = "Samsung TV 50Inch",
                    Price = 1200

                },

                iPhone
            };

            //var products = new List<Product>();

            //var iphoneXR128 = new Product();
            //iphoneXR128.Name = "iPhone XR 128";
            //iphoneXR128.Price = 599;

            //var iphoneXR128 = new Product()
            //{
            //    Name = "iPhone XR 128",
            //    Price = 599
            //};



            //var iphone11ProMax512 = new Product();
            //iphoneXR128.Name = "iPhone 11 Pro Max 512";
            //iphoneXR128.Price = 1200;

            //var iphone11ProMax512 = new Product()
            //{
            //    Name = "iPhone Pro Max 512",
            //    Price = 1200
            //};


            //products.Add(iphoneXR128);
            //products.Add(iphone11ProMax512);



            //return products;
        }

        internal static IEnumerable<object> GetProduct()
        {
            throw new NotImplementedException();
        }
    }
}
