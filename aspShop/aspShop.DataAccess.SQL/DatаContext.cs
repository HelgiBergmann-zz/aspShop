using aspShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspShop.DataAccess.SQL
{
    public class DatаContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DatаContext()
            :base("Default Connection")
        {

        }
    }
}
