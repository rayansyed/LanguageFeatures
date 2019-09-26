using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace W3_LanguageFeatures1.Models
{
    public class ShoppingCart
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
