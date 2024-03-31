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
        // Preset categories for different product types
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
        /// <summary>
        /// Display the product if the product is within (range) amount of (val).
        /// </summary>
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
        /// <summary>
        /// Analytic function for average value and standard deviation.
        /// </summary>
        /// <returns>double[2] { <Average> , <Deviation> }</returns>
        public double[] AverageProductValue()
        {
            double average = GetMinimalHolding() / Products.Count;
            double DEVIATION = 0;

            foreach (Product product in Products)
            {
                DEVIATION += Math.Pow(product.Price - average, 2);
            }

            DEVIATION = Math.Sqrt(DEVIATION / Products.Count);

            return new double[2] { average, DEVIATION };
        }
        public void AddProduct(string name, double price, int quantity, string category, string manufacturer)
        {
            // If product entry already exists in the database, implicitly add the quantity
            if (Products.Exists(p => p.Name == name && p.Manufacturer == manufacturer && p.Category == category))
            {
                Product p = Products.Find(x => x.Name == name && x.Manufacturer == manufacturer && x.Category == category);
                p.Quantity += quantity;

                Console.WriteLine($"Product {p.Name} already in inventory, adding to the quantity...");
                Console.WriteLine($"Updated: {p}");
            }
            else
            {
                // Create new product entry
                Product newprod = new Product(name, price, quantity, category, manufacturer);
                Products.Add(newprod);
                Console.WriteLine("Product successfully added.\n");
            }
        }
        /// <summary>
        /// Get the net value of the products
        /// </summary>
        public double GetTotalHolding()
        {
            double totalHolding = 0;
            foreach (Product p in Products)
            {
                totalHolding += p.Price * p.Quantity;
            }
            return totalHolding;
        }
        /// <summary>
        /// Get the value which represents the lowest possible net value without removing products
        /// </summary>
        public double GetMinimalHolding()
        {
            double minimalHolding = 0;
            foreach (Product p in Products)
            {
                minimalHolding += p.Price;
            }
            return minimalHolding;
        }
        /// <summary>
        /// Remove product based on ID
        /// </summary>
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
        /// <summary>
        /// List all products
        /// </summary>
        public void RawList()
        {
            foreach (Product p in Products)
            {
                Console.WriteLine(p);
            }
        }
        /// <summary>
        /// Save data to Database
        /// </summary>
        public void SerializeInventory()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Inventory.xml");

            var serializer = new XmlSerializer(typeof(List<Product>));

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, Products);
            }
        }
        /// <summary>
        /// Load data from Database
        /// </summary>
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
