using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    public class Order
    {
        public List<Product> OrderedProducts { get; set; }
        public DateTime OrderTimestamp { get; set; }
        public Order(List<Product> orderedProducts)
        {
            OrderedProducts = orderedProducts;
            OrderTimestamp = DateTime.Now;
        }
    }
}
