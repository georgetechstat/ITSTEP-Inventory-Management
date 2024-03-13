using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    public class Product
    {
        public Product(string id, string name, double price, int quantity, string category, string manufacturer)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            Manufacturer = manufacturer;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price}$, Quantity: {Quantity}, Category: {Category}, Manufacturer: {Manufacturer}";
        }
    }
}
