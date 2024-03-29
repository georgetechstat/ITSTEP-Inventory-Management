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
