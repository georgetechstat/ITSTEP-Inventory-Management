using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Inventory_Management
{
    public class InventoryManager
    {
        public List<Product> Products { get; set; }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public bool RemoveProduct(string productId)
        {
            return false;
        }
        public void DisplayInventory()
        {
            Products.ForEach(product => { Console.WriteLine(product.ToString()); });
        }
        public void ExportOrder()
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
            return Products.Count;
        }
        /// <summary>
        /// Sum up all prices of products.
        /// Sum = foreach (p in ps) { sum(p.Price * p.Qty) } return sum;
        /// </summary>
        /// <returns></returns>
        public double GetTotalHolding()
        {
            double totalHolding = 0;
            foreach (Product p in Products)
            {
                totalHolding += p.Price * p.Quantity;
            }
            return totalHolding;
        }
        public void SerializeInventory()
        {
            var serializer = new XmlSerializer(typeof(List<Product>));

            using (var writer = new StreamWriter("Inventory.xml"))
            {
                serializer.Serialize(writer, Products);
            }
        }
        public void DeserializeInventory()
        {
            var serializer = new XmlSerializer(typeof(List<Product>));

            using (var reader = new StreamReader("Inventory.xml"))
            {
                Products = (List<Product>)serializer.Deserialize(reader);
            }
        }
    }
}
