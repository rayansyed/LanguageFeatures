using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace W3_LanguageFeatures1.Models
{
    public class Product
    {
        public string Name { get; set; } 

        public decimal Price { get; set; }

        public string Category { get; } = "phones";

        public Product RelatedProduct { get; set; }


        public Product()
        {

        }



        public double Square(double x)
        {
            return x * x;
        }


        Func<double, double> coolSquare = x => x * x;


    }
}
