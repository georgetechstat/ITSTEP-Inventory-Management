using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    public class InventoryManager
    {
        public List<Product> Products { get; set; }
        public Stack<Product> RecentProducts { get; set; }
        public Queue<Product> Orders { get; set; }
        public void AddProduct(Product product)
        {

        }
        public bool RemoveProduct(string productId)
        {
            return false;
        }
        public void DisplayInventory()
        {

        }
        public void ProcessOrder()
        {

        }
        public Product SearchProductByName(string productName)
        {
            return null;
        }
        public List<Product> SearchProductByCategory(string category)
        {
            return null;
        }
        public int GetTotalProducts()
        {
            return 1;
        }
        public double GetTotalRevenue()
        {
            return 0.1;
        }
        public void SerializeInventory()
        {

        }
        public void DeserializeInventory()
        {

        }
    }
}
