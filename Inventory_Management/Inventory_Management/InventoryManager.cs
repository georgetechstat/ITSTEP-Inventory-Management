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
            Products = new List<Product>();
            Categories = new List<string>()
            {
                "Furniture",
                "Tool",
                "Electric"
            };
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
                Console.WriteLine("Product successfully added.");
            }
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
