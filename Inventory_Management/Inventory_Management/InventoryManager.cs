using System;
using System.Collections.Generic;
using System.Collections;
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
        public List<string> Categories { get; set; }

        public InventoryManager()
        {
            DeserializeInventory();
            Categories = new List<string>()
            {
                "Furniture",
                "Tool",
                "Electric"
            };
        }
        public void RangeList(double val, double range)
        {
            double lower = val - range;
            double higher = val + range;

            foreach (Product product in Products)
            {
                if (product.Price >= lower && product.Price <= higher)
                {
                    Console.WriteLine(product);
                }
            }
        }
        public double[] AverageProductValue()
        {
            double average = GetMinimalHolding() / Products.Count;
            double SUMMATION = 0;

            foreach (Product product in Products)
            {
                SUMMATION += Math.Pow(product.Price - average, 2);
            }

            SUMMATION = Math.Sqrt(SUMMATION / Products.Count);

            return new double[2] { average, SUMMATION };
        }
        public void AddProduct(string name, double price, int quantity, string category, string manufacturer)
        {
            if (Products.Exists(p => p.Name == name && p.Manufacturer == manufacturer && p.Category == category))
            {
                Product p = Products.Find(x => x.Name == name && x.Manufacturer == manufacturer && x.Category == category);
                p.Quantity += quantity;

                Console.WriteLine($"Product {p.Name} already in inventory, adding to the quantity...");
                Console.WriteLine($"Updated: {p}");
            }
            else
            {
                Product newprod = new Product(name, price, quantity, category, manufacturer);
                Products.Add(newprod);
                Console.WriteLine("Product successfully added.\n");
            }
        }
        public double GetTotalHolding()
        {
            double totalHolding = 0;
            foreach (Product p in Products)
            {
                totalHolding += p.Price * p.Quantity;
            }
            return totalHolding;
        }
        public double GetMinimalHolding()
        {
            double minimalHolding = 0;
            foreach (Product p in Products)
            {
                minimalHolding += p.Price;
            }
            return minimalHolding;
        }
        public void RemoveProduct(long productID)
        {
            Product delisted = Products.Find(p => p.UId == productID);
            if (delisted == null)
            {
                Console.WriteLine($"No product matching the id: {productID}");
            }
            else
            {
                Products.Remove(delisted);
                Console.WriteLine($"Product {delisted.Name} successfully removed.");
            }
        }
        public void RawList()
        {
            foreach (Product p in Products)
            {
                Console.WriteLine(p);
            }
        }
        public void SerializeInventory()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Inventory.xml");

            var serializer = new XmlSerializer(typeof(List<Product>));

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, Products);
            }
        }
        public void DeserializeInventory()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Inventory.xml");

            if (!File.Exists(path))
            {
                Products = new List<Product>();
            }
            else
            {
                var serializer = new XmlSerializer(typeof(List<Product>));

                using (var reader = new StreamReader(path))
                {
                    Products = (List<Product>)serializer.Deserialize(reader);
                }
            }
        }
    }
}
