using aspShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace aspShop.Models
{
    public class Category: IBaseProps
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Category()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
