using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspShop.Models
{
    public class ProductManager
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public ProductManager ()
        {
            Product = new Product();
        }
    }
}
