using aspShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspShop.ViewModels
{
    public class ProductList
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public ProductList()
        {
 
        }
    }
}
