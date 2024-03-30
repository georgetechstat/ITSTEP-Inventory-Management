using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    public class Product
    {
        public Product(string name, double price, int quantity, string category, string manufacturer)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            Manufacturer = manufacturer;

            Id += 1;
            UId = Id;
        }

        public static long Id { get; set; }
        public long UId { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public override string ToString()
        {
            return $"ID: {UId}, Name: {Name}, Price: {Price}$, Quantity: {Quantity}, Category: {Category}, Manufacturer: {Manufacturer}";
        }
    }
}
