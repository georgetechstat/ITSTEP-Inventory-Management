using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inventory_Management
{
    public class Product
    {
        // _idCounter: Id tracker when deserializing products
        private static long _idCounter = 0;
        /// <summary>
        /// Parameterless constructor used for serialization/deserialization
        /// Keeps track of ids for proper data storing.
        /// </summary>
        public Product()
        {
            UId = ++_idCounter;
            Id = _idCounter;
        }
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
        [XmlIgnore]
        public long UId { get; }
        [XmlElement("UId")]
        public long UIdForSerialization // Property for serialization
        {
            get { return UId; }
            set { } // Set accessor is empty to prevent deserialization from modifying UId
        }
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
